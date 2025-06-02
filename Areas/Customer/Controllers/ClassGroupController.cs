
using Microsoft.AspNetCore.Identity;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using IdentityText.Models.ViewModel;
using IdentityText.Repository;
using IdentityText.Enums;
using System;


namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ClassGroupController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public ClassGroupController(
         IClassGroupRepository classGroupRepository,
         ITeacherRepository teacherRepository,
         IStudentRepository studentRepository,
         IAcademicYearRepository academicYearRepository,
         ISubjectRepository subjectRepository,
         UserManager<ApplicationUser> userManager)  // inject here
        {
            _classGroupRepository = classGroupRepository;
            _teacherRepository = teacherRepository;
            _academicYearRepository = academicYearRepository;
            _subjectRepository = subjectRepository;
            _userManager = userManager;
            _studentRepository = studentRepository;
        }
        //public async Task<IActionResult> CouresAsync()
        //{
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    var classGroup = _classGroupRepository.Get();
        //    if (classGroup == null)
        //    {
        //        return NotFound();
        //    }
        //    foreach (var item in classGroup)
        //    {
        //        // Check if the user is enrolled in the class group

        //        //item.CGStatus = ClassGroupStatus.NotPurchased; // Default status
        //        foreach (var enrollment in item.Enrollments)
        //        {
        //            if (enrollment.Student.ApplicationUser.Id == currentUser.Id)
        //            {
        //                item.CGStatus = ClassGroupStatus.Purchased;
        //                break; 
        //            }
        //        }

                // Assuming you want to check if the user is enrolled in the class group
                //var student = _studentRepository.GetOne(s => s.ApplicationUser.Id == currentUser.Id);
                //if (student != null)
                //{
                //    foreach (var enrollment in item.Enrollments)
                //    {
                //        if (enrollment.StudentId == student.StudentId)
                //        {
                //            item.CGStatus = ClassGroupStatus.Purchased;
                //            _classGroupRepository.Edit(item);
                //            break; // No need to check further enrollments for this class group
                //        }
                //    }
                //}
        //    }
        //    return View(classGroup);
        //}

        public IActionResult Details(int id)
        {
            var classGroup = _classGroupRepository.GetWithFullIncludes(e=>e.ClassGroupId == id).FirstOrDefault();
            if(classGroup == null)
            {
                return NotFound();
            }
            return View(classGroup);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Assuming your Teacher entity has a property ApplicationUserId that links to Identity user Id
            var teacher = _teacherRepository.Get(t => t.ApplicationUser.Id == currentUser.Id).FirstOrDefault();

            var model = new ClassGroupVM
            {
                AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync(),
                TeacherId = teacher?.TeacherId ?? 0,
                SubjectId = teacher?.SubjectId ?? 0,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassGroupVM model)
        {
            if (ModelState.IsValid)
            {
                var classGroup = new ClassGroup
                {
                    Title = model.Title,
                    Location = model.Location,
                    Price = model.Price,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    AcademicYearId = model.AcademicYearId,
                    SubjectId = model.SubjectId,
                    TeacherId = model.TeacherId
                };
                _classGroupRepository.Create(classGroup);
                _classGroupRepository.Commit();
                TempData["notification"] = "Successfully Created";
                return RedirectToAction(controllerName: "Home", actionName:"Index");
            }
            model.AcademicYearsList = await _academicYearRepository.SelectListAcademicYearAsync();
            model.SubjectsList = await _subjectRepository.SelectListSubjectAsync();
            model.TeacherList = await _teacherRepository.SelectListTeacherAsync();
            return View(model);
        }


    }
}
