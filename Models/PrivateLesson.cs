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
    public class PrivateLesson
    {
        [Key]
        public int PrivateLessonId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [BindNever]
        public ICollection<PrivateLessonStudent> PrivateLessonStudents { get; set; }


    }

}
