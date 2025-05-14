using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LectureController : Controller
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IClassGroupRepository _classGroupRepository;

        public LectureController(ILectureRepository lectureRepository, IClassGroupRepository classGroupRepository)
        {
            _lectureRepository = lectureRepository;
            _classGroupRepository = classGroupRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var lectures = _lectureRepository.Get(includes: [ l => l.Assessment, l => l.ClassGroup]);
            var classGroups = _classGroupRepository.Get();
            return View(lectures);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var lecture = _lectureRepository.GetOne(e => e.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var classGroups = _classGroupRepository.Get();
            return View(new Lecture());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                _lectureRepository.CreateAsync(lecture);
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lecture = _lectureRepository.GetOne(e => e.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                _lectureRepository.Edit(lecture);
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var lecture = _lectureRepository.GetOne(e => e.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }
            _lectureRepository.Delete(lecture);
            _lectureRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
