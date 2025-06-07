using IdentityText.Enums;
using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class LectureController : Controller
    {
        private readonly ILectureRepository _lectureRepository;
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IAssessmentRepository _assessmentRepository;

        public LectureController(ILectureRepository lectureRepository, IEnrollmentRepository enrollmentRepository, IClassGroupRepository classGroupRepository, IAssessmentRepository assessmentRepository)
        {
            _lectureRepository = lectureRepository;
            _classGroupRepository = classGroupRepository;
            _assessmentRepository = assessmentRepository;
            _enrollmentRepository = enrollmentRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var lectures = _lectureRepository.Get(includes: [e=>e.Assessment,e=>e.ClassGroup] );
            return View(lectures);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var model = new LectureVM
            {
                AssessmentList = await _assessmentRepository.SelectListAssessmentAsync(),
                ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(LectureVM model)
        {
            if (ModelState.IsValid)
            {
                var lecture = new Lecture
                {
                    Title = model.Title,
                    Description= model.Description,
                    LectureDate = model.LectureDate,
                    VideoURL = model.VideoURL,
                    CreatedAt = model.CreatedAt,
                    ClassGroupId = model.ClassGroupId,
                    AssessmentId = model.AssessmentId
                };
                _lectureRepository.Create(lecture);
                _lectureRepository.Commit();
                TempData["notification"] = "Successfully Created";
                return RedirectToAction(nameof(Index));
            }
            model.AssessmentList = await _assessmentRepository.SelectListAssessmentAsync();
            model.ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var lecture = _lectureRepository.GetOne( filter: e => e.LectureId == id);

            if (lecture == null)
            {
                return NotFound();
            }

            var model = new LectureVM
            {
                LectureId = lecture.LectureId,
                Title = lecture.Title,
                Description = lecture.Description,
                LectureDate = lecture.LectureDate,
                VideoURL = lecture.VideoURL,
                CreatedAt = lecture.CreatedAt,
                ClassGroupId = lecture.ClassGroupId,
                AssessmentId = lecture.AssessmentId,
                AssessmentList = await _assessmentRepository.SelectListAssessmentAsync(),
                ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(LectureVM model)
        {

            if (ModelState.IsValid)
            {
                var lecture = _lectureRepository.GetOne(filter: e => e.LectureId == model.LectureId);
                if (lecture == null)
                {
                    return NotFound(); // Handle the case where classGroup is null
                }
                lecture.LectureId =model.LectureId;
                lecture.Title = model.Title;
                lecture.Description = model.Description;
                lecture.LectureDate = model.LectureDate;
                lecture.VideoURL = model.VideoURL;
                lecture.CreatedAt = model.CreatedAt;
                lecture.ClassGroupId = model.ClassGroupId;
                lecture.AssessmentId = model.AssessmentId;
                _lectureRepository.Edit(lecture);
                _lectureRepository.Commit();
                TempData["notification"] = "Successfully Edited";
                return RedirectToAction(nameof(Index));
            }
            model.AssessmentList = await _assessmentRepository.SelectListAssessmentAsync();
            model.ClassGroupList = await _classGroupRepository.SelectListClassGroupAsync();
            return View(model);
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
            _lectureRepository.Commit();
            TempData["notification"] = "Successfully Deleted";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Attendance(int id)
        {
            var lecture = _lectureRepository.GetOne(filter: e => e.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }
            //get all enrollments for the class group of the lecture
            var enrollments = _enrollmentRepository.Get(
                filter: e => e.ClassGroupId == lecture.ClassGroupId && e.EnrollmentStatus == EnrollmentStatus.Active,
                includes: [e => e.Student, e => e.Student.ApplicationUser]);

            var count = enrollments.Count();

            var model = enrollments.Where(e => e.Student != null && e.Student.ApplicationUser != null)
                .Select(e => new StudentAttendanceVM
            {
                EnrollmentId = e.EnrollmentId,
                StudentId = e.StudentId,
                StudentName = e.Student.ApplicationUser.FirstName,
                IsPresent = false 
            }).ToList();

            ViewBag.LectureId = id;
            ViewBag.ClassGroupId = lecture.ClassGroupId;
            ViewBag.StudentNumber = count;

            return View(model);
        }

    }
}
