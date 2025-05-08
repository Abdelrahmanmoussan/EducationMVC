
using IdentityText.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [MaxLength(20)]
        public PaymentMethod PaymentMethod { get; set; } // مثلا: Cash, Visa

        public string Notes { get; set; }

        public decimal PlatformPercentage { get; set; }
        public decimal NetAmountForTeacher { get; set; }

        [MaxLength(20)]
        public PaymentStatus PaymentStatus { get; set; } // مثلا: Paid, Pending
    }

}
