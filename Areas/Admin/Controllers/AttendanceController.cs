using IdentityText.Enums;
using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Teacher")]
    public class AttendanceController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailSender _emailSender;

        public AttendanceController(
            IClassGroupRepository classGroupRepository,
            ILectureRepository lectureRepository,
            IAttendanceRepository attendanceRepository,
            IStudentRepository studentRepository,
            IEnrollmentRepository enrollmentRepository,
            IEmailSender emailSender)
        {
            _classGroupRepository = classGroupRepository;
            _lectureRepository = lectureRepository;
            _attendanceRepository = attendanceRepository;
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _emailSender = emailSender;
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> TakeAttendance()
        {
            var model = new StudentAttendanceVM
            {
                ClassGroups = (List<SelectListItem>)await _classGroupRepository.SelectListClassGroupAsync(),
                Lectures = new List<SelectListItem>(),
                AttendanceStatusList = _attendanceRepository.GetAttendanceStatusSelectList(),
                Students = new List<StudentVM>(),
                Attendances = new List<AttendanceEntry>()
            };

            return View(model);
        }

        // AJAX endpoint to get lectures for class group
        [HttpGet]
        public IActionResult GetLecturesByClassGroup(int classGroupId)
        {
            var lectures = _lectureRepository.Get(filter: l => l.ClassGroupId == classGroupId)
                .Select(l => new { id = l.LectureId, title = l.Title });


            return Json(lectures);
        }

        // AJAX endpoint to get students
        [HttpGet]
        public IActionResult GetStudentsByClassGroup(int classGroupId)
        {
            var students = _enrollmentRepository.Get(filter: e => e.ClassGroupId == classGroupId, includes: [e => e.Student.ApplicationUser])
                .Select(e => new {
                    id = e.Student.StudentId,
                    fullName = e.Student.ApplicationUser.FirstName + " " + e.Student.ApplicationUser.LastName,
                    email = e.Student.ApplicationUser.Email
                });

            return Json(students);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAttendanceAsync(StudentAttendanceVM model)
        {
            foreach (var entry in model.Attendances)
            {
                // Get EnrollmentId for this student and class group
                var enrollment = _enrollmentRepository
                    .Get(filter: e => e.StudentId == entry.StudentId && e.ClassGroupId == model.ClassGroupId,
                    includes: [e => e.ClassGroup.Lectures])
                    .FirstOrDefault();

                if (enrollment == null)
                    continue; // Skip if enrollment not found

                // check if attendance already exists
                var existingAttendance = _attendanceRepository.GetOne(
                    filter: a => a.StudentId == entry.StudentId && a.LectureId == model.LectureId);

                if (existingAttendance != null)
                {
                    // update existing attendance
                    existingAttendance.AttendanceStatus = entry.AttendanceStatus;
                    existingAttendance.Remark = entry.Remark;
                    existingAttendance.Date = DateTime.Now;

                    _attendanceRepository.Edit(existingAttendance);
                }
                else
                {
                    var attendance = new Attendance
                    {
                        StudentId = entry.StudentId,
                        LectureId = model.LectureId,
                        AttendanceStatus = entry.AttendanceStatus,
                        Remark = entry.Remark,
                        Date = DateTime.Now,
                        CreatedAt = DateTime.UtcNow,
                        EnrollmentId = enrollment.EnrollmentId
                    };
                    _attendanceRepository.Create(attendance);

                    if (entry.AttendanceStatus == AttendanceStatus.Absent)
                    {
                        var student = _studentRepository.GetOne(
                            filter: s => s.StudentId == entry.StudentId,
                            includes: [s => s.ApplicationUser]);

                        var currentLecture = enrollment.ClassGroup?.Lectures
                            ?.FirstOrDefault(l => l.LectureId == model.LectureId);

                        if (student != null
                            && !string.IsNullOrEmpty(student.ParentMail)
                            && currentLecture != null)
                        {
                            string studentName = $"{student.ApplicationUser.FirstName} {student.ApplicationUser.LastName}";
                            string lectureDate = currentLecture.LectureDate.ToString("yyyy-MM-dd");

                            string subject = "تنبيه غياب الطالب";
                            string message = $"نود إعلامكم أن الطالب {studentName} قد تغيب عن المحاضرة بتاريخ {lectureDate}.";

                            await _emailSender.SendEmailAsync(student.ParentMail, subject, message);
                        }
                    }
                }
            }

            _attendanceRepository.Commit();

            return RedirectToAction("ShowAttendance");

        }

        [HttpGet]
        public IActionResult ShowAttendance(int? classGroupId, int? lectureId)
        {
            var allAttendances = _attendanceRepository.Get(includes: [
                a => a.Student.ApplicationUser,
                a => a.Lecture,
                a => a.Enrollment.ClassGroup
            ]);

            if (allAttendances == null || !allAttendances.Any())
            {
                TempData["Error"] = "لا توجد سجلات حضور.";
                return RedirectToAction("TakeAttendance");  
            }

            if (classGroupId.HasValue)
                TempData["SelectedClassGroupId"] = classGroupId.Value;

            if (lectureId.HasValue)
                TempData["SelectedLectureId"] = lectureId.Value;

            var filteredAttendances = allAttendances
                .Where(a => (!classGroupId.HasValue || a.Enrollment.ClassGroupId == classGroupId)
                         && (!lectureId.HasValue || a.LectureId == lectureId))
                .ToList();

            return View(filteredAttendances);
        }


        [HttpGet]
        public async Task<IActionResult> AbsenceSummary(int? classGroupId)
        {
            var allAttendances = _attendanceRepository.Get(includes: [
                a => a.Student.ApplicationUser,
                a => a.Lecture,
                a => a.Enrollment.ClassGroup
                    ]);

            if (allAttendances == null || !allAttendances.Any())
            {
                TempData["Error"] = "لا توجد سجلات حضور.";
                return RedirectToAction("TakeAttendance");
            }

            ViewBag.ClassGroups = allAttendances
            .Where(a => a.Enrollment != null && a.Enrollment.ClassGroup != null)
            .Select(a => a.Enrollment.ClassGroup)
            .GroupBy(cg => cg.ClassGroupId)
            .Select(g => g.First())
            .ToList();

            if (classGroupId.HasValue)
            {
                ViewBag.SelectedClassGroupId = classGroupId.Value;
                var grouped = allAttendances
                    .Where(a => a.Enrollment.ClassGroupId == classGroupId.Value && a.AttendanceStatus == AttendanceStatus.Absent)
                    .GroupBy(a => a.Student)
                    .Select(g => new StudentAttendanceReportVM
                    {
                        Student = g.Key,
                        AbsenceCount = g.Count()
                    }).ToList();

                return View(grouped);
            }

            return View(new List<StudentAttendanceReportVM>());
        }

        [HttpPost]
        public async Task<IActionResult> NotifyParent(int studentId, int classGroupId)
        {
            var absences = _attendanceRepository.Get(
                filter: a => a.AttendanceStatus == AttendanceStatus.Absent && a.StudentId == studentId && a.Enrollment.ClassGroupId == classGroupId,
                includes: [a => a.Student.ApplicationUser, a => a.Enrollment.ClassGroup]
            );

            var student = absences.FirstOrDefault()?.Student;
            var classGroup = absences.FirstOrDefault()?.Enrollment.ClassGroup;

            if (student != null && !string.IsNullOrEmpty(student.ParentMail) && classGroup != null)
            {
                string subject = "تنبيه: تجاوز عدد الغيابات";
                string message = $"عزيزي ولي الأمر، الطالب {student.ApplicationUser.FirstName} {student.ApplicationUser.LastName} <br> قد تغيّب {absences.Count()} مرات عن كورس {classGroup.Title}.";

                await _emailSender.SendEmailAsync(student.ParentMail, subject, message);

                TempData["Success"] = $"تم إرسال التنبيه لولي أمر الطالب {student.ApplicationUser.FirstName} بنجاح.";
            }

            return RedirectToAction("AbsenceSummary", new { classGroupId });
        }


    }
}
