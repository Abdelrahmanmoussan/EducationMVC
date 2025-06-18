﻿using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using IdentityText.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;



namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Teacher")]

    public class AssessmentController : Controller
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAssessmentResultRepository _assessmentResultRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly INotificationRepository _notificationRepository;
        public AssessmentController(
            IAssessmentRepository assessmentRepository,
            IAssessmentResultRepository assessmentResultRepository,
            ILectureRepository lectureRepository,
            INotificationRepository notificationRepository,
            IClassGroupRepository classGroupRepository)
        {
            _assessmentRepository = assessmentRepository;
            _assessmentResultRepository = assessmentResultRepository;
            _lectureRepository = lectureRepository;
            _notificationRepository = notificationRepository;
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
                    DeliveryDate = model.DeliveryDate,
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
                DeliveryDate = assessment.DeliveryDate,
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
                assessment.DeliveryDate = model.DeliveryDate;
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
   

        public IActionResult ReviewSolutions(int assessmentId)
        {
            var assessment = _assessmentRepository.GetOne(e => e.AssessmentId == assessmentId);
            if (assessment == null)
                return NotFound();

            var results = _assessmentResultRepository.Get(e => e.AssessmentId == assessmentId,
                includes: [e => e.Student.ApplicationUser]);

           
            var vm = new AssessmentSolutionsVM
            {
                AssessmentId = assessmentId,
                AssessmentTitle = assessment.Title,
                StudentSolutions = results.Select(r => new StudentSolutionVM
                {
                    AssessmentResultId = r.AssessmentResultId,
                    StudentName = r.Student.ApplicationUser.FirstName+" "+ r.Student.ApplicationUser.LastName,
                    SolutionLink = r.StudentSolutionPath,
                    Score = r.Score,
                    Grade = r.Grade,
                    Feedback = r.Feedback
                }).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Evaluate(int id)
        {
            var result =_assessmentResultRepository.GetOne(
                filter: e=>e.AssessmentResultId == id,
                includes: [e=>e.Student.ApplicationUser]);

            if (result == null)
                return NotFound();

            var assessment = _assessmentRepository.GetOne(e=>e.AssessmentId == result.AssessmentId);
            if (assessment == null)
                return NotFound();

            ViewBag.MaxScore = assessment.MaxScore;
            var vm = new StudentSolutionVM
            {
                AssessmentResultId = result.AssessmentResultId,
                StudentName = result.Student.ApplicationUser.FirstName +" "+ result.Student.ApplicationUser.LastName,
                SolutionLink = result.StudentSolutionPath,
                Score = result.Score,
                Grade = result.Grade,
                Feedback = result.Feedback
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Evaluate(StudentSolutionVM vm)
        {
            var result = _assessmentResultRepository.GetOne(e => e.AssessmentResultId == vm.AssessmentResultId,
                includes: [e => e.Student.ApplicationUser]);

            if (result == null)
                return NotFound();

            var ass = _assessmentRepository.GetOne(e => e.AssessmentId == result.AssessmentId);
            if (ass == null)
                return NotFound();

            result.Score = vm.Score ?? 0;
            result.Grade = GradeHelper.GetGrade(result.Score, ass.MaxScore);
            result.Feedback = vm.Feedback;

            _assessmentResultRepository.Edit(result);
            _assessmentRepository.Commit();

            var notification = new Notification
            {
                Message = $"تم تقييمك في '{ass.Title}' وحصلت على درجة {result.Grade}",
                IsRead = false,
                Date = DateTime.Now,
                UserId = result.Student.UserId,
                NotificationRecipients = new List<NotificationRecipient>
                {
                    new NotificationRecipient
                    {
                        DeliveryByGmail = false,
                        IsDelivered = false,
                        UserId = result.Student.ApplicationUser.Id,
                    }
                }
            };

            var studentUserId = result.Student.ApplicationUser.Id;
            //notification.NotificationRecipients.First().UserId = studentUserId;

            _notificationRepository.Create(notification);
            _notificationRepository.Commit();

            TempData["EvaluationMessage"] = $"تم تقييم الطالب {result.Student.ApplicationUser.FirstName} {result.Student.ApplicationUser.LastName} بنجاح بدرجة {result.Grade}";
            return RedirectToAction("ReviewSolutions", new { assessmentId = result.AssessmentId });
        }



    }
   
}
