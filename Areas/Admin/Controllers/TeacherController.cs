using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISubjectRepository _subjectRepository;

        public TeacherController(ITeacherRepository teacherRepository, ISubjectRepository subjectRepository)
            {
                _teacherRepository = teacherRepository;
                _subjectRepository = subjectRepository;
        }

            public  IActionResult Index()
            {
                var teachers =  _teacherRepository.Get();
            return View(teachers);
            }

            public async Task<IActionResult> Details(int id)
            {
                var teacher = await _teacherRepository.GetByIdWithIncludesAsync(id);
                if (teacher == null) return NotFound();
                return View(teacher);
            }

            public IActionResult Create()
            {
            var subjects = _subjectRepository.Get();
            ViewBag.SubjectId = new SelectList(subjects, "SubjectId", "Title");

            return View(new Teacher { UserId = string.Empty });
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Teacher teacher)
            {
                if (ModelState.IsValid)
                {
                    _teacherRepository.Create(teacher);
                    return RedirectToAction(nameof(Index));
                }
                return View(teacher);
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                    var teacher =  _teacherRepository.GetOne(e => e.TeacherId == id, includes: [a=>a.ApplicationUser, e=>e.Subject]);
            if (ModelState.IsValid)
            {
                var subjects = _subjectRepository.Get();
                ViewBag.SubjectId = new SelectList(subjects, "SubjectId", "Title", teacher.SubjectId);
            }
                    if (teacher == null) return NotFound();
                    return View(teacher);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, Teacher teacher)
            {
            var existingTeacher = _teacherRepository.GetOne(e => e.TeacherId == id);

            if (id != teacher.TeacherId) return NotFound();

                if (ModelState.IsValid)
                {
                     _teacherRepository.Edit(teacher);
                    return RedirectToAction(nameof(Index));
                }
                return View(teacher);
            }

            public IActionResult Delete(int id)
            {
                var teacher =  _teacherRepository.GetOne(e=>e.TeacherId == id);
            if (teacher != null)
            {
                _teacherRepository.Delete(teacher);
                return RedirectToAction(nameof(Index));
            }
                if (teacher == null) return NotFound();
                return View(teacher);
            }


        
    }
}
