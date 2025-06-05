using IdentityText.Enums;
using IdentityText.Models;
using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Student")]
    public class LectureController : Controller
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public LectureController(
            ILectureRepository lectureRepository,
            IEnrollmentRepository enrollmentRepository,
            IStudentRepository studentRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _lectureRepository = lectureRepository;
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
            _userManager = userManager;
        }
        public IActionResult Index(int classGroupId)
        {
            var userId = _userManager.GetUserId(User);
            var currentStudent = _studentRepository.GetOne(s => s.UserId == userId);
            if(currentStudent == null)
            {
                return NotFound();
            }

            var isEnrolled = _enrollmentRepository.Get(filter:
                e => e.ClassGroupId == classGroupId &&
                e.StudentId == currentStudent.StudentId &&
                e.EnrollmentStatus == EnrollmentStatus.Active,
                includes: [e=>e.ClassGroup, e => e.Student.ApplicationUser]
            ).Any();

            if (!isEnrolled)
            {
                TempData["Error"] = "يجب أن تكون مشتركًا في هذا الكورس.";
                return RedirectToAction("Index", "Home");
            }

            var lectures = _lectureRepository.Get(filter: l => l.ClassGroupId == classGroupId,includes:[e=>e.ClassGroup,e=>e.Assessment,e=>e.Attendances]);
            ViewBag.ClassGroupId = classGroupId;
            return View(lectures);
        }
    }
}
