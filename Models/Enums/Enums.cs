using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Enums
{
    public enum RoleStatus
    {
        Student,
        Teacher
    }

    public enum ParentStatus
    {
        Father,
        Mother,
        Others
    }

    public enum EnrollmentStatus
    {
        Active,
        Canceled,
        Completed,
        PendingPayment
    }

    public enum AttendanceStatus
    {
        Present,
        Abset
    }

    public enum SubscriptionStatus
    {
        Active,
        Expired
    }

    public enum PaymentMethod
    {
        Cash,
        Visa,
        MasterCard,
        BankTransfer,
        Other
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed,
        Cancelled
    }


    public enum TeacherStatus
    {
        Online,
        Offline
    }
    public enum SubjectType
    {
        General,    // مادة أساسية
        Optional,// مادة اختيارية
        Theoretical,
        Practical,
        Mixed
    }

}
