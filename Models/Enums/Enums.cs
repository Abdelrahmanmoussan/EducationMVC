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
        Completed
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

    public enum PaymentStatus
    {
        Paid,
        Pending
    }

    public enum PaymentMethod
    {
        Cash,
        Visa
    }

    public enum TeacherStatus
    {
        Online,
        Offline
    }
    public enum SubjectType
    {
        General,    // مادة أساسية
        Optional    // مادة اختيارية
    }

}
