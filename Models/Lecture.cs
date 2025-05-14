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
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime LectureDate { get; set; }

        public string VideoURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public int? AttendanceId { get; set; }
        //public Attendance Attendance { get; set; }
        
        public int? AssessmentId { get; set; }

        public Assessment Assessment { get; set; }
        [Required]
        public int ClassGroupId { get; set; }
        public ClassGroup ClassGroup { get; set; }
        [BindNever]
        public ICollection<Attendance> Attendances { get; set; }

    }

}
