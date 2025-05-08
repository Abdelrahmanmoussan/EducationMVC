using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassGroupController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public ClassGroupController(IClassGroupRepository classGroupRepository, ISubjectRepository subjectRepository, ITeacherRepository teacherRepository)
        {
            _classGroupRepository = classGroupRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var classGroups = _classGroupRepository.Get(includes: [e=>e.Teacher , e=>e.Subject]);
            return View(classGroups);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var classGroup = _classGroupRepository.GetOne(e => e.ClassGroupId == id, includes: [e => e.Teacher, e => e.Subject]);
            if (classGroup == null)
            {
                return NotFound();
            }
            return View(classGroup);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var subjects = _subjectRepository.Get();
            var teachers = _teacherRepository.Get(includes: [t => t.ApplicationUser]);
            ViewBag.SubjectId = new SelectList(subjects, "SubjectId", "Title");
            ViewBag.TeacherId = new SelectList(teachers, "TeacherId", "ApplicationUser.Email");

            return View(new ClassGroup
            {
                Title = string.Empty, 
                Location = string.Empty, 
                Subject = new Subject { Title = string.Empty },   
                Teacher = new Teacher { UserId = string.Empty } 
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassGroup classGroup)
        {
            if (ModelState.IsValid)
            {
                _classGroupRepository.CreateAsync(classGroup);
                return RedirectToAction(nameof(Index));
            }
            var subjects = _subjectRepository.Get();
            var teachers = _teacherRepository.Get(includes: [t => t.ApplicationUser]);
            ViewBag.SubjectId = new SelectList(subjects, "SubjectId", "Title");
            ViewBag.TeacherId = new SelectList(teachers, "TeacherId", "ApplicationUser.Email");
            return View(classGroup);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var classGroup = _classGroupRepository.GetOne(e => e.ClassGroupId == id, includes: [e => e.Teacher, e => e.Subject]);
            if (classGroup == null)
            {
                return NotFound();
            }
            var subjects = _subjectRepository.Get();
            var teachers = _teacherRepository.Get(includes: [t => t.ApplicationUser]);
            ViewBag.SubjectId = new SelectList(subjects, "SubjectId", "Title");
            ViewBag.TeacherId = new SelectList(teachers, "TeacherId", "ApplicationUser.Email");
            return View(classGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassGroup classGroup)
        {
            if (ModelState.IsValid)
            {
                _classGroupRepository.Edit(classGroup);
                return RedirectToAction(nameof(Index));
            }
            var subjects = _subjectRepository.Get();
            var teachers = _teacherRepository.Get(includes: [t => t.ApplicationUser]);
            ViewBag.SubjectId = new SelectList(subjects, "SubjectId", "Title");
            ViewBag.TeacherId = new SelectList(teachers, "TeacherId", "ApplicationUser.Email");
            return View(classGroup);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var classGroup = _classGroupRepository.GetOne(e => e.ClassGroupId == id, includes: [e => e.Teacher, e => e.Subject]);
            if (classGroup == null)
            {
                return NotFound();
            }
            _classGroupRepository.Delete(classGroup);
            _classGroupRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
