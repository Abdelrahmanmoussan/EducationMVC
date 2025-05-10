using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var subjects = _subjectRepository.Get();
            return View(subjects);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var subject = _subjectRepository.GetOne(e=>e.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Subject());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subject subject)
        {
                await _subjectRepository.CreateAsync(subject);
                return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subject = _subjectRepository.GetOne(e => e.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }
        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
                _subjectRepository.Edit(subject);
                return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var subject = _subjectRepository.GetOne(e => e.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            _subjectRepository.Delete(subject);
            _subjectRepository.CommitAsync();

            return RedirectToAction("Index");
        }











    }
}
