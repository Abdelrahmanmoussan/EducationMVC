using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Admin.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassGroupRepository _classGroupRepository;

        public PaymentController(IPaymentRepository paymentRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository, IClassGroupRepository classGroupRepository)
        {
            _paymentRepository = paymentRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _classGroupRepository = classGroupRepository;
        }
        public IActionResult Index()
        {
            var payments = _paymentRepository.Get();
            return View(payments);
        }




            
    }
}
