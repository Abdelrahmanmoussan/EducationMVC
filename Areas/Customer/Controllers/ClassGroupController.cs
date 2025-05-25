using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ClassGroupController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly ISubjectRepository _subjectRepository;

        public ClassGroupController(
            IClassGroupRepository classGroupRepository,
            ITeacherRepository teacherRepository,
            IAcademicYearRepository academicYearRepository,
            ISubjectRepository subjectRepository)
        {
            _classGroupRepository = classGroupRepository;
            _teacherRepository = teacherRepository;
            _academicYearRepository = academicYearRepository;
            _subjectRepository = subjectRepository;
        }
        public IActionResult Details(int id)
        {
            var classGroup = _classGroupRepository.GetWithFullIncludes(e=>e.ClassGroupId == id).FirstOrDefault();
            return View(classGroup);
        }
    }
}
