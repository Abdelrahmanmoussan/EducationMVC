using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClassGroupController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassGroupController(IClassGroupRepository classGroupRepository,
            ISubjectRepository subjectRepository,
            ITeacherRepository teacherRepository,
            UserManager<ApplicationUser> userManager,
            IAcademicYearRepository academicYearRepository)
        {
            _classGroupRepository = classGroupRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _academicYearRepository = academicYearRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var classGroups = _classGroupRepository.Get( includes: [e => e.AcademicYear, e => e.Subject, e => e.Teacher.ApplicationUser]);
            return View(classGroups);
        }


        [HttpGet]
        public IActionResult GetTeachersBySubject(int subjectId)
        {
            var teachers = _teacherRepository.Get(
                filter: t => t.SubjectId == subjectId,
                includes: [ t => t.ApplicationUser ]
            )
            .Select(t => new
            {
                teacherId = t.TeacherId,
                fullName = t.ApplicationUser.FirstName + " " + t.ApplicationUser.LastName
            });
            return Json(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var model = new ClassGroupVM
            {
                AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync(),
                SubjectsList = await _subjectRepository.SelectListSubjectAsync(),
                TeacherList = await _teacherRepository.SelectListTeacherAsync()
            };

            return View(model);
        }

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
                return RedirectToAction(nameof(Index));
            }
            model.AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync();
            model.SubjectsList = await _subjectRepository.SelectListSubjectAsync();
            model.TeacherList = await _teacherRepository.SelectListTeacherAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var classGroup = _classGroupRepository.GetOne(e => e.ClassGroupId == id);
            if (classGroup == null)
            {
                return NotFound(); // Handle the case where classGroup is null
            }

            var model = new ClassGroupVM
            {
                ClassGroupId = classGroup.ClassGroupId,
                Title = classGroup.Title,
                Location = classGroup.Location,
                Price = classGroup.Price,
                StartDate = classGroup.StartDate,
                EndDate = classGroup.EndDate,
                SubjectId = classGroup.SubjectId,
                TeacherId = classGroup.TeacherId,
                AcademicYearId = classGroup.AcademicYearId,
                AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync(),
                SubjectsList = await _subjectRepository.SelectListSubjectAsync(),
                TeacherList = await _teacherRepository.SelectListTeacherAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(ClassGroupVM model)
        {
            if (ModelState.IsValid)
            {
                var classGroup = _classGroupRepository.GetOne(e => e.ClassGroupId == model.ClassGroupId);
                if (classGroup == null)
                {
                    return NotFound(); // Handle the case where classGroup is null
                }
                classGroup.Title = model.Title;
                classGroup.Location = model.Location;
                classGroup.Price = model.Price;
                classGroup.StartDate = model.StartDate;
                classGroup.EndDate = model.EndDate;
                classGroup.SubjectId = model.SubjectId;
                classGroup.TeacherId = model.TeacherId;
                classGroup.AcademicYearId = model.AcademicYearId;
                _classGroupRepository.Edit(classGroup);
                _classGroupRepository.Commit();
                TempData["notification"] = "Successfully Edited";
                return RedirectToAction(nameof(Index));
            }
            model.AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync();
            model.SubjectsList = await _subjectRepository.SelectListSubjectAsync();
            model.TeacherList = await _teacherRepository.SelectListTeacherAsync();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var classGroup = _classGroupRepository.GetOne(e => e.ClassGroupId == id);
            if (classGroup == null)
            {
                return NotFound();
            }
            _classGroupRepository.Delete(classGroup);
            _classGroupRepository.Commit();
            TempData["notification"] = "Successfully Deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}
