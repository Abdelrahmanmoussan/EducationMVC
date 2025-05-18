using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Admin.Controllers
{
    public class AssessmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
