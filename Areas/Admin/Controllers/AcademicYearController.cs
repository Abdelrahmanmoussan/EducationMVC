using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AcademicYearController : Controller
    {
        private readonly IAcademicYearRepository _academicYearRepository;

        public AcademicYearController(IAcademicYearRepository academicYearRepository)
        {
            _academicYearRepository = academicYearRepository;
        }

        public IActionResult Index()
        {
            var academicYears = _academicYearRepository.Get();
            return View(academicYears);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var academicYear = _academicYearRepository.GetOne(e => e.AcademicYearId == id);
            if (academicYear == null)
            {
                return NotFound();
            }
            return View(academicYear);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AcademicYear { Name = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                await _academicYearRepository.CreateAsync(academicYear);
                return RedirectToAction(nameof(Index));
            }
            return View(academicYear);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var academicYear = _academicYearRepository.GetOne(e => e.AcademicYearId == id);
            if (academicYear == null)
            {
                return NotFound();
            }
            return View(academicYear);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AcademicYear academicYear)
        {
 
                _academicYearRepository.Edit(academicYear);
                return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var academicYear = _academicYearRepository.GetOne(e => e.AcademicYearId == id);
            if (academicYear == null)
            {
                return NotFound();
            }
            _academicYearRepository.Delete(academicYear);
            _academicYearRepository.CommitAsync();
            return RedirectToAction("Index");
        }









    }
}
