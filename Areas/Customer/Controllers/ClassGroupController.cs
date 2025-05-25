
using Microsoft.AspNetCore.Identity;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using IdentityText.Models.ViewModel;


namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ClassGroupController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public ClassGroupController(
         IClassGroupRepository classGroupRepository,
         ITeacherRepository teacherRepository,
         IAcademicYearRepository academicYearRepository,
         ISubjectRepository subjectRepository,
         UserManager<ApplicationUser> userManager)  // inject here
        {
            _classGroupRepository = classGroupRepository;
            _teacherRepository = teacherRepository;
            _academicYearRepository = academicYearRepository;
            _subjectRepository = subjectRepository;
            _userManager = userManager;
        }

        public IActionResult Details(int id)
        {
            var classGroup = _classGroupRepository.GetWithFullIncludes(e=>e.ClassGroupId == id).FirstOrDefault();
            return View(classGroup);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Assuming your Teacher entity has a property ApplicationUserId that links to Identity user Id
            var teacher = _teacherRepository.Get(t => t.ApplicationUser.Id == currentUser.Id).FirstOrDefault();

            var model = new ClassGroupVM
            {
                AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync(),
                TeacherId = teacher?.TeacherId ?? 0,
                SubjectId = teacher?.SubjectId ?? 0,
            };

            return View(model);
        }


        //[HttpGet]
        //public IActionResult GetTeachersBySubject(int subjectId)
        //{
        //    var teachers = _teacherRepository.Get(
        //        filter: t => t.SubjectId == subjectId,
        //        includes: new Expression<Func<Teacher, object>>[] { t => t.ApplicationUser }
        //    )
        //    .Select(t => new
        //    {
        //        teacherId = t.TeacherId,
        //        fullName = t.ApplicationUser.FirstName + " " + t.ApplicationUser.LastName
        //    });
        //    return Json(teachers);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassGroupVM model)
        {
            if (ModelState.IsValid)
            {
                var classGroup = new ClassGroup
                {
                    Title = model.Title,
                    Location = model.Location,
                    Price = model.Price,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    AcademicYearId = model.AcademicYearId,
                    SubjectId = model.SubjectId,
                    TeacherId = model.TeacherId
                };
                _classGroupRepository.Create(classGroup);
                _classGroupRepository.Commit();
                TempData["notification"] = "Successfully Created";
                return RedirectToAction(controllerName: "Home", actionName:"Index");
            }
            model.AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync();
            model.SubjectsList = await _subjectRepository.SelectListSubjectAsync();
            model.TeacherList = await _teacherRepository.SelectListTeacherAsync();
            return View(model);
        }
    }
}
