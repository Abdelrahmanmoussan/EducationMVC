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
    public class ClassGroup
    {
        [Key]
        public int ClassGroupId { get; set; }

        [Required]
        public required string Title { get; set; }

        [MaxLength(200)]
        public required string Location { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10,000$.")]
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int SubjectId { get; set; }
        [Required] 
        public required Subject Subject { get; set; } 

        public int TeacherId { get; set; }
        [Required] 
        public required Teacher Teacher { get; set; }

        [BindNever]
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        [BindNever]
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
        [BindNever]
        public ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
    }

}
