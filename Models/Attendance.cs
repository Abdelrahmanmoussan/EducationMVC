

using IdentityText.Enums;
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
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public AttendanceStatus AttendanceStatus { get; set; } // مثلا: Present, Absent, Late

        public string Notes { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Required]
        public int EnrollmentId { get; set; }

        public Enrollment Enrollment { get; set; }

        [BindNever]
        public ICollection<Lecture> Lectures { get; set; }
    }

}
