using IdentityText.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public required string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        
        [MaxLength(100)]
        public string? ParentName { get; set; }

       
        [Phone]
        public string? ParentPhone { get; set; }

      
        [EmailAddress]
        public string? ParentMail { get; set; }


        [DataType(DataType.Date)]
        public DateTime? StudentDB { get; set; }
        [DataType(DataType.Date)]
       
        public DateTime EnrollmentDate { get; set; }

        [MaxLength(50)]
        public string? GradeLevel { get; set; }
     
        [MaxLength(100)]
        public string? EmergencyContact { get; set; }
        [Range(0, 100)]
        public decimal AttendancePercent { get; set; }
        [MaxLength(500)]
        public string? StudentNotes { get; set; }
        public bool StudentIsActive { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        [BindNever]
        public ICollection<AssessmentResult> AssessmentResults { get; set; }
        [BindNever]
        public ICollection<Payment> payments { get; set; }
        [BindNever]
        public ICollection<PrivateLessonStudent> PrivateLessonStudents { get; set; }
        [BindNever]
        public ICollection<Enrollment> Enrollments { get; set; }
        
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        [Required]
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }

    }


}
