
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
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public required string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime TeacherHireDate { get; set; }

        public DateTime? TeacherDB { get; set; }

        [MaxLength(100)]
        public string? Specialty { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Salary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TeacherNetAmount { get; set; }

        public string? TeacherNotes { get; set; }

        public bool TeacherIsActive { get; set; } = true;

        /// <summary>
        /// ///////add when registration//////////
        /// </summary>
        [Required]
        public int SubjectId { get; set; }

        [Required] 
        public Subject Subject { get; set; }
        [BindNever]
        public ICollection<AcademicYear> AcademicYears { get; set; }
        [BindNever]
        public ICollection<Payment> Payments { get; set; }
        [BindNever]
        public ICollection<PrivateLesson> PrivateLessons { get; set; }
        [BindNever]
        public ICollection<ClassGroup> ClassGroups { get; set; }
        [BindNever]
        public ICollection<TeacherAcademicYear> TeacherAcademicYears { get; set; }
    }

}


