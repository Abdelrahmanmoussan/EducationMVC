using IdentityText.Models;
using IdentityText.Models.ViewModel;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ILectureRepository _lectureRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(
            IClassGroupRepository classGroupRepository,
            ILectureRepository lectureRepository,
            IAttendanceRepository attendanceRepository,
            IEnrollmentRepository enrollmentRepository)
        {
            _classGroupRepository = classGroupRepository;
            _lectureRepository = lectureRepository;
            _attendanceRepository = attendanceRepository;
            _enrollmentRepository = enrollmentRepository;
        }
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
                    email = e.Student.ApplicationUser.Email });

            return Json(students);
        }

        [HttpPost]
        public IActionResult SaveAttendance(StudentAttendanceVM model)
        {
            foreach (var entry in model.Attendances)
            {
                // Get EnrollmentId for this student and class group
                var enrollment = _enrollmentRepository
                    .Get(filter: e => e.StudentId == entry.StudentId && e.ClassGroupId == model.ClassGroupId)
                    .FirstOrDefault();

                if (enrollment == null)
                    continue; // Skip if enrollment not found

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
    }
}
