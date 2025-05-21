using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Teacher")]

    public class AssessmentController : Controller
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IClassGroupRepository _classGroupRepository;
        public AssessmentController(IAssessmentRepository assessmentRepository,ILectureRepository lectureRepository,IClassGroupRepository classGroupRepository)
        {
            _assessmentRepository = assessmentRepository;
            _lectureRepository = lectureRepository;
            _classGroupRepository = classGroupRepository;
        }
        public IActionResult Index()
        {
            var assessments = _assessmentRepository.GetWithFullIncludes(
                include: q => q.Include(a => a.Lecture).ThenInclude(l => l.ClassGroup));
            if (assessments == null)
            {
                return NotFound();
            }
            return View(assessments);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var model = new AssessmentVM
            {
                LectureList = await _lectureRepository.SelectListLectureAsync(),
                ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync()
            };

            return View(model);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(AssessmentVM model)
        {
            if (ModelState.IsValid)
            {
                var assessment = new Assessment
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    CreatedAt = model.CreatedAt,
                    AssessmentLink = model.AssessmentLink,
                    MaxScore = model.MaxScore,
                    LectureId = model.LectureId,
                };
                _assessmentRepository.Create(assessment);
                _assessmentRepository.Commit();
                TempData["notification"] = "Successfully Created";
                return RedirectToAction(nameof(Index));
            }
            model.LectureList = await _lectureRepository.SelectListLectureAsync();
            model.ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync(); 
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var assessment = _assessmentRepository.GetOneWithFullIncludes(
                filter: e => e.AssessmentId == id,
                  include: q => q.Include(a => a.Lecture).ThenInclude(l => l.ClassGroup));

            if (assessment == null)
            {
                return NotFound();
            }

            var model = new AssessmentVM
            {
                AssessmentId = assessment.AssessmentId,
                Title = assessment.Title,
                Description = assessment.Description,
                Date = assessment.Date,
                CreatedAt = assessment.CreatedAt,
                AssessmentLink = assessment.AssessmentLink,
                MaxScore = assessment.MaxScore,
                LectureId = assessment.LectureId,
                ClassGroupId = assessment.Lecture.ClassGroupId,
                LectureList = await _lectureRepository.SelectListLectureAsync(),
                ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync()
            };
            return View(model);
        }
        [HttpGet]
        public JsonResult GetLecturesByClassGroup(int classGroupId)
        {
            var lectures = _lectureRepository.Get(filter: l => l.ClassGroupId == classGroupId)
                                            .Select(l => new { l.LectureId, l.Title });

            return Json(lectures);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(AssessmentVM model)
        {

            if (ModelState.IsValid)
            {
                //var assessment = _assessmentRepository.GetOne(filter: e => e.AssessmentId == model.AssessmentId);
                var assessment = _assessmentRepository.GetOneWithFullIncludes(
                filter: e => e.AssessmentId == model.AssessmentId,
                  include: q => q.Include(a => a.Lecture).ThenInclude(l => l.ClassGroup));
                if (assessment == null)
                {
                    return NotFound(); // Handle the case where classGroup is null
                }
                assessment.AssessmentId = model.AssessmentId;
                assessment.Title = model.Title;
                assessment.Description = model.Description;
                assessment.Date = model.Date;
                assessment.CreatedAt = model.CreatedAt;
                assessment.AssessmentLink = model.AssessmentLink;
                assessment.MaxScore = model.MaxScore;
                assessment.LectureId = model.LectureId;

                _assessmentRepository.Edit(assessment);
                _assessmentRepository.Commit();
                TempData["notification"] = "Successfully Edited";
                return RedirectToAction(nameof(Index));
            }
            model.LectureList = await _lectureRepository.SelectListLectureAsync();
            model.ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync();
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var assessment = _assessmentRepository.GetOneWithFullIncludes(
               filter: e => e.AssessmentId ==id,
                 include: q => q.Include(a => a.Lecture).ThenInclude(l => l.ClassGroup));
            if (assessment == null)
            {
                return NotFound();
            }
            _assessmentRepository.Delete(assessment);
            _assessmentRepository.Commit();
            TempData["notification"] = "Successfully Deleted";
            return RedirectToAction(nameof(Index));
        }


    }
}
