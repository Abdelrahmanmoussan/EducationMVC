using IdentityText.Models;
using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrivateLessonController : Controller
    {
        private readonly IPrivateLessonRepository _privateLessonRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public PrivateLessonController(IPrivateLessonRepository privateLessonRepository, ISubjectRepository subjectRepository,ITeacherRepository teacherRepository)
        {
            _privateLessonRepository = privateLessonRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var privateLessons = _privateLessonRepository.Get();
            return View(privateLessons);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var privateLesson = _privateLessonRepository.GetOne(p => p.PrivateLessonId == id);
            if (privateLesson == null)
            {
                return NotFound();
            }
            return View(privateLesson);
        }   

        [HttpGet]
        public IActionResult Create()
        {
            var subjects = _subjectRepository.Get();
            var teachers = _teacherRepository.Get(includes: [t => t.ApplicationUser]);


            ViewBag.SubjectId = new SelectList(subjects, "SubjectId", "Title");
            ViewBag.TeacherId = new SelectList(teachers, "TeacherId", "ApplicationUser.Email");
            return View(new PrivateLesson());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PrivateLesson privateLesson)
        {
            if (ModelState.IsValid)
            {
                _privateLessonRepository.CreateAsync(privateLesson);
                return RedirectToAction(nameof(Index));
            }
            return View(privateLesson);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var privateLesson = _privateLessonRepository.Get(p => p.PrivateLessonId == id).FirstOrDefault();
            if (privateLesson == null)
            {
                return NotFound();
            }
            return View(privateLesson);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PrivateLesson privateLesson)
        {
            if (ModelState.IsValid)
            {
                _privateLessonRepository.Edit(privateLesson);
                return RedirectToAction(nameof(Index));
            }
            return View(privateLesson);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var privateLesson = _privateLessonRepository.GetOne(p => p.PrivateLessonId == id);
            if (privateLesson == null)
            {
                return NotFound();
            }
            _privateLessonRepository.Delete(privateLesson);
            _privateLessonRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
