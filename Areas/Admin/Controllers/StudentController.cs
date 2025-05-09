using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IAcademicYearRepository _academicYearRepository;

        public StudentController(IStudentRepository studentRepository, IAcademicYearRepository academicYearRepository)
        {
            _studentRepository = studentRepository;
            _academicYearRepository = academicYearRepository;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllAsync();
            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentRepository.GetByIdWithIncludesAsync(id); // Include ApplicationUser
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var students = await _studentRepository.GetAllWithIncludesAsync();
            var academicYears =  _academicYearRepository.Get();
            ViewBag.AcademicYearId = new SelectList(academicYears, "AcademicYearId", "Name");

            return View(new Student { UserId = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.AddAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId) return NotFound();

            if (ModelState.IsValid)
            {
                await _studentRepository.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
