using IdentityText.Enums;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public EnrollmentController(
            IClassGroupRepository clasGroupRepository,
            IEnrollmentRepository enrollmentRepository,
            IPaymentRepository paymentRepository,
            IStudentRepository studentRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _clasGroupRepository = clasGroupRepository;
            _userManager = userManager;
            _enrollmentRepository = enrollmentRepository;
            _paymentRepository = paymentRepository;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            var enrollments = _enrollmentRepository
                .Get(e => e.Student.UserId == userId, includes: [e => e.ClassGroup, e => e.Student.ApplicationUser])
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

        public IActionResult ProcessPayment(int id)
        {
            var payment = _paymentRepository.GetOne(p => p.EnrollmentId == id);
            if (payment == null)
            {
                TempData["notification"] = "عملية الدفع غير موجودة.";
                return View(payment);
            }
            return View(payment);
        }

        [HttpPost]
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
            enrollment.EnrollmentStatus = EnrollmentStatus.Active;
            _enrollmentRepository.Edit(enrollment);
            _enrollmentRepository.Commit();

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
