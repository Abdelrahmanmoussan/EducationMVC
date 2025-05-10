using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using IdentityText.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly IPaymentRepository _paymentRepository;

        public AdminController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IClassGroupRepository classGroupRepository, IPaymentRepository paymentRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _classGroupRepository = classGroupRepository;
            _paymentRepository = paymentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var studentsCount = await _studentRepository.CountAsync();
            var teachersCount = await _teacherRepository.CountAsync();
            var totalCourses = await _classGroupRepository.CountAsync();
            var totalRevenue = await _paymentRepository.GetTotalRevenueAsync();
            var todaySales = await _paymentRepository.GetTodaySalesAsync();

            // بيانات تجريبية - يمكنك لاحقًا ربطها بالداتا الحقيقية
            var recentTransactions = new List<RecentTransaction>
    {
        new() { StudentName = "محمد علي", Amount = 250, Date = DateTime.Now.AddHours(-2) },
        new() { StudentName = "أحمد خالد", Amount = 300, Date = DateTime.Now.AddHours(-6) },
    };

            var messages = new List<DashboardMessage>
    {
        new() { SenderName = "الأستاذة فاطمة", MessagePreview = "يرجى مراجعة الجدول الجديد...", SentAt = DateTime.Now.AddMinutes(-20) },
        new() { SenderName = "الأستاذ حسين", MessagePreview = "تم رفع الحصة المسجلة", SentAt = DateTime.Now.AddHours(-1) },
    };

            var calendarEvents = new List<CalendarEvent>
    {
        new() { Title = "امتحان نهاية الشهر", EventDate = DateTime.Today.AddDays(3) },
        new() { Title = "حصة مراجعة", EventDate = DateTime.Today.AddDays(1) },
    };

            var todoList = new List<TodoItem>
    {
        new() { Task = "متابعة تسجيل الطلاب", IsCompleted = false },
        new() { Task = "إرسال إشعارات الجدول", IsCompleted = true },
    };

            var model = new DashboardViewModel
            {
                StudentsCount = studentsCount,
                TeachersCount = teachersCount,
                TotalCourses = totalCourses,
                TotalRevenue = totalRevenue,
                TodaySales = todaySales,
                RecentTransactions = recentTransactions,
                RecentMessages = messages,
                CalendarEvents = calendarEvents,
                TodoList = todoList
            };

            return View(model);
        }




    }
}
