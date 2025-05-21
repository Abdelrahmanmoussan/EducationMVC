using IdentityText.Models;
using IdentityText.Repository.IRepository;
using IdentityText.ViewModel.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IdentityText.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly ITeacherRepository _teacherRepository;

        public HomeController(ILogger<HomeController> logger,IClassGroupRepository classGroupRepository, ITeacherRepository teacherRepository)
        {
            _logger = logger;
            _classGroupRepository = classGroupRepository;
            _teacherRepository = teacherRepository;
        }


        public async Task<IActionResult> Index()
        {
            // بيانات ترحيبية
            ViewBag.WelcomeMessage = "أهلاً بيك في موقعنا!";
            ViewBag.AboutUs = "نحن نقدم أفضل الخدمات التعليمية مع مدرسين محترفين.";
            ViewBag.ContactUs = "يمكنك التواصل معنا على البريد الإلكتروني: info@example.com أو عبر الهاتف 0123456789";

            // جلب المدرسين مع ApplicationUser
            var allTeachers = await _teacherRepository.GetAllWithIncludesAsync(); // تأكد انه بيعمل Include(ApplicationUser) داخليًا
            var popularTeachers = allTeachers
                .OrderByDescending(t => t.Rating) // لازم يكون عندك خاصية Rating
                .Take(5)
                .ToList();

            // جلب الكورسات (Include داخلي من GetWithFullIncludes)
            var allCourses = _classGroupRepository.GetWithFullIncludes(); // تأكد انه بيعمل Include لـ Teacher و ApplicationUser
            var popularCourses = allCourses
                .OrderByDescending(c => c.Enrollments.Count)
                .Take(5)
                .ToList();

            var portfolio = popularCourses;

            var model = new HomeViewModel
            {
                PopularTeachers = popularTeachers,
                PopularClassGroups = popularCourses,
                Portfolio = portfolio
            };

            return View(model);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
