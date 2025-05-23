using IdentityText.Repository.IRepository;
using IdentityText.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace IdentityText.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassGroupRepository _classGroupRepository;
        private readonly IPaymentRepository _paymentRepository;

        public HomeController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IClassGroupRepository classGroupRepository, IPaymentRepository paymentRepository)
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

            var recentTransactions = await _paymentRepository.GetTodaySalesAsync();
            //var messages = await _messageRepository.GetRecentMessagesAsync();
            //var calendarEvents = await _eventRepository.GetUpcomingEventsAsync();
            //var todoList = await _todoRepository.GetAdminTodoListAsync();

            var model = new DashboardViewModel
            {
                StudentsCount = studentsCount,
                TeachersCount = teachersCount,
                TotalCourses = totalCourses,
                TotalRevenue = totalRevenue,
                TodaySales = todaySales,
                //RecentTransactions = recentTransactions,
                //RecentMessages = messages,
                //CalendarEvents = calendarEvents,
                //TodoList = todoList
            };

            return View(model);
        }
    }
}
