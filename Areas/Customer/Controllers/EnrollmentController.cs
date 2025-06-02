using IdentityText.Enums;
using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe.Climate;
using System.Linq.Expressions;

namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Student")]
    public class EnrollmentController : Controller
    {
        private readonly IClassGroupRepository _clasGroupRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly StripePaymentService _stripePaymentService;


        public EnrollmentController(
            IClassGroupRepository clasGroupRepository,
            IEnrollmentRepository enrollmentRepository,
            IPaymentRepository paymentRepository,
            IStudentRepository studentRepository,
            UserManager<ApplicationUser> userManager,
            StripePaymentService stripePaymentService
            )
        {
            _clasGroupRepository = clasGroupRepository;
            _userManager = userManager;
            _enrollmentRepository = enrollmentRepository;
            _paymentRepository = paymentRepository;
            _studentRepository = studentRepository;
            _stripePaymentService = stripePaymentService;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            var enrollments = _enrollmentRepository
                .Get(e => e.Student.UserId == userId,
                includes: [e => e.ClassGroup, e => e.Student.ApplicationUser])
                .ToList();
            if (enrollments == null || !enrollments.Any())
            {
                return View(new List<Enrollment>());
            }
            
            return View(enrollments);
        }

        public async Task<IActionResult> RegisterAsync(int id)
        {
            var currentCG = _clasGroupRepository.GetOne(e => e.ClassGroupId == id);
            var currentUser = await _userManager.GetUserAsync(User);
            var student = _studentRepository.GetOne(s => s.UserId == currentUser.Id);
            var userId = student.StudentId;
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            // التحقق من عدم وجود تسجيل سابق لنفس الطالب في نفس المجموعة
            bool alreadyEnrolled = _enrollmentRepository
                .Get(e => e.ClassGroupId == id && e.StudentId == userId)
                .Any();
            if (alreadyEnrolled)
            {
                TempData["Error"] = "أنت مسجل بالفعل في هذه المجموعة.";
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            // create enrollment
            var enrollment = new Enrollment
            {
                ClassGroupId = currentCG.ClassGroupId,
                StudentId = userId, // Convert string to int
                EnrollmentDate = DateTime.Now,
                EnrollmentStatus = EnrollmentStatus.PendingPayment, // حالة الانتظار حتى الدفع
                Notes = "تم التسجيل في المجموعة " + currentCG.Title + " في " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
               
            };
            _enrollmentRepository.Create(enrollment);
            _enrollmentRepository.Commit();
            // create Payment
            var payment = new Models.Payment
            {
                EnrollmentId = enrollment.EnrollmentId,
                Amount = currentCG.Price,
                PaymentDate = DateTime.Now,
                PaymentStatus = PaymentStatus.Pending,
                PaymentMethod = PaymentMethod.Cash,
                PlatformPercentage = 0.10m, 
                NetAmountForTeacher = currentCG.Price * (1 - 0.10m) ,
                Notes = "Payment for enrollment in class group " + currentCG.Title
            };
            _paymentRepository.Create(payment);
            _paymentRepository.Commit();
            TempData["notification"] = "تم التسجيل في الكورس وتم انشاء دفع له";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult ProcessPayment(int id)
        {
            var payment = _paymentRepository.GetOne(
                p => p.EnrollmentId == id,
                includes:[ p => p.Enrollment, p => p.Enrollment.ClassGroup]
                );

            if (payment == null)
            {
                TempData["notification"] = "عملية الدفع غير موجودة.";
                return RedirectToAction("Index", "Enrollment"); // إعادة التوجيه لصفحة الكورسات أو صفحة مناسبة
            }
            if (payment.Enrollment == null || payment.Enrollment.ClassGroup == null)
            {
                TempData["notification"] = "بيانات التسجيل غير مكتملة.";
                return RedirectToAction("Index", "Enrollment");
            }
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "EGP",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = payment.Enrollment.ClassGroup.Title,
                        Description = $"السنة الدراسية: {payment.Enrollment.ClassGroup.AcademicYear?.Name ?? "غير محدد"}  | بداية الكورس: {payment.Enrollment.ClassGroup.StartDate.ToString("yyyy-MM-dd")} | طريقة الدفع: {payment.PaymentMethod}"
                    },
                    UnitAmount = (long)(payment.Amount * 100), 
                     },
                     Quantity = 1,
                 }
                },
                    Mode = "payment",
                    SuccessUrl = $"{Request.Scheme}://{Request.Host}/Customer/Enrollment/ConfirmPayment?paymentId={payment.PaymentId}",
                    CancelUrl = $"{Request.Scheme}://{Request.Host}/Customer/Enrollment/Cancel",
                };

            var service = new SessionService();
            var session = service.Create(options);

            return Redirect(session.Url);
        }

        [HttpGet]
        public IActionResult ConfirmPayment(int paymentId)
        {
            var payment = _paymentRepository.GetOne(p => p.PaymentId == paymentId);
            if (payment == null)
            {
                TempData["notification"] = "عملية الدفع غير موجودة.";
                return NotFound();
            }
            
            payment.PaymentStatus = PaymentStatus.Paid;
            _paymentRepository.Edit(payment);
            _paymentRepository.Commit();

            var enrollment = _enrollmentRepository.GetOne(e => e.EnrollmentId == payment.EnrollmentId);
            if(enrollment != null) {
                enrollment.EnrollmentStatus = EnrollmentStatus.Active;
                _enrollmentRepository.Edit(enrollment);
                _enrollmentRepository.Commit();
            }
            TempData["notification"] = "تم تأكيد الدفع والتسجيل بنجاح.";
            return RedirectToAction(actionName:"Index", controllerName:"Home");
        }


        public IActionResult Delete(int id)
        {
            var enrollment = _enrollmentRepository.GetOne(e => e.EnrollmentId == id);
            if (enrollment == null )
            {
                return NotFound();
            }
            _enrollmentRepository.Delete(enrollment);
            _enrollmentRepository.Commit();
            TempData["notification"] = "Successfully Delete your enrollment ";
            return RedirectToAction("Index");
        }


    }
}
