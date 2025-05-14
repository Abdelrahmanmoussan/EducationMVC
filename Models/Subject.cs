using IdentityText.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public SubjectType SubjectType { get; set; } // Enum مثلاً: General, 
        [BindNever]
        public ICollection<SubjectAcademicYear> SubjectAcademicYears { get; set; } = new List<SubjectAcademicYear>();
        [BindNever]
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        [BindNever]
        public ICollection<ClassGroup> ClassGroups { get; set; }
        [BindNever]
        public ICollection<PrivateLesson> PrivateLessons { get; set; }
    }

}
