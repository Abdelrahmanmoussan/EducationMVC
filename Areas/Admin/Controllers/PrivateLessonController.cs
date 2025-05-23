using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
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
            var privateLessons = _privateLessonRepository.Get(includes: [e => e.Teacher.ApplicationUser,e=>e.Subject]  );
            //var privateLessons = _privateLessonRepository.GetWithFullIncludes(
            //   include: c => c.Include(a => a.Teacher).ThenInclude(l => l.ApplicationUser)
            //      .Include(a => a.Subject));

            if (privateLessons == null)
            {
                return NotFound();
            }
            return View(privateLessons);
        }
  

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new PrivateLessonVM
            {
                TeacherList = await _teacherRepository.SelectListTeacherAsync(),
                SubjectList = await _subjectRepository.SelectListSubjectAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(PrivateLessonVM model)
        {
            if (ModelState.IsValid)
            {
                var privateLesson = new PrivateLesson
                {
                    Price = model.Price,
                    Title = model.Title,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    SubjectId = model.SubjectId,
                    TeacherId = model.TeacherId,
                };
                _privateLessonRepository.Create(privateLesson);
                _privateLessonRepository.Commit();
                TempData["notification"] = "Successfully Created";
                return RedirectToAction(nameof(Index));
            }
            model.TeacherList = await _teacherRepository.SelectListTeacherAsync();
            model.SubjectList = await _subjectRepository.SelectListSubjectAsync();
            return View(model);
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
            _privateLessonRepository.Commit();
            return RedirectToAction(nameof(Index));
        }

       [HttpGet]
public JsonResult GetTeachersBySubject(int subjectId)
{
    // جلب المدرسين المرتبطين بالمادة
    var teachers = _teacherRepository.Get(s => s.SubjectId == subjectId, includes: [e=>e.ApplicationUser])
        .Select(t => new
        {
            TeacherId = t.TeacherId,
            FullName = t.ApplicationUser.FirstName + " " + t.ApplicationUser.LastName
        }).ToList();

    return Json(teachers);
}





    }
}
