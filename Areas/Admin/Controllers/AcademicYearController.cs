using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Admin.Controllers
{
    public class AcademicYearController : Controller
    {
        private readonly IAcademicYearRepository _academicYearRepository;

        public AcademicYearController(IAcademicYearRepository academicYearRepository)
        {
            _academicYearRepository = academicYearRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
