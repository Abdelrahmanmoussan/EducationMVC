using IdentityText.Models;
using IdentityText.Models.ViewModel;
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
            var allTeachers =  _teacherRepository.GetAllWithIncludesAsync(include: q => q.Include(a => a.ApplicationUser).Include(l => l.Subject)); // تأكد انه بيعمل Include(ApplicationUser) داخليًا
            var popularTeachers = allTeachers
                .OrderByDescending(t => t.Rating) // لازم يكون عندك خاصية Rating
                .Take(6)
                .ToList();


            var allCourses = _classGroupRepository.Get();
            if(allCourses == null || !allCourses.Any())
            {
                return View(new HomeViewModel
                {
                    PopularTeachers = popularTeachers,
                    PopularClassGroups = new List<ClassGroup>(),
                    Portfolio = new List<ClassGroup>()
                });
            }
            var popularCourses = allCourses
                .Where(c => c.Enrollments != null)
                .OrderByDescending(c => c.Enrollments.Count)
                .Take(6)
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

        public async Task<IActionResult> TeacherDetails(int TeacherId)
        {
            var teacher = await _teacherRepository.GetByIdWithIncludesAsync(TeacherId);
            var related = _teacherRepository.GetAllWithIncludesAsync(filter:e=>e.SubjectId == teacher.SubjectId ,include: q => q.Include(a => a.ApplicationUser).Include(l => l.Subject));

            if (teacher == null)
            {
                return NotFound();
            }

            var model = new TeacherDetailsViewModel
            {
                Teacher = teacher,
                ClassGroups = (List<ClassGroup>)_classGroupRepository.GetWithFullIncludes(c => c.TeacherId == teacher.TeacherId)
            };

            ViewBag.relatedTeachers = related
                .OrderByDescending(t => t.Rating)
                .Take(5)
                .ToList();
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
