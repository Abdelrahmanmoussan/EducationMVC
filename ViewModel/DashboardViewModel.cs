
namespace IdentityText.ViewModel
{
    public class DashboardViewModel
    {
        public int StudentsCount { get; set; }
        public int TeachersCount { get; set; }
        public int TotalCourses { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TodaySales { get; set; }

        public List<RecentTransaction> RecentTransactions { get; set; } = new();
        public List<DashboardMessage> RecentMessages { get; set; } = new();
        public List<CalendarEvent> CalendarEvents { get; set; } = new();
        public List<TodoItem> TodoList { get; set; } = new();
    }

    public class RecentTransaction
    {
        public string StudentName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class DashboardMessage
    {
        public string SenderName { get; set; }
        public string MessagePreview { get; set; }
        public DateTime SentAt { get; set; }
    }

    public class CalendarEvent
    {
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
    }

    public class TodoItem
    {
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }

}
