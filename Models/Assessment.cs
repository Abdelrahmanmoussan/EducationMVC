using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Models
{
    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public string AssessmentLink { get; set; }

        [Required]
        public int MaxScore { get; set; }

        [Required]
        public int ClassGroupId { get; set; }
        public ClassGroup ClassGroup { get; set; }

        [BindNever]
        public ICollection<AssessmentResult> AssessmentResults { get; set; }
        [BindNever]
        public ICollection<Lecture> Lectures { get; set; }
    }

}
