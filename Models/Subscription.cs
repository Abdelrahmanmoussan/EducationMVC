
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
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } // Unique code

        [Required]
        [MaxLength(20)]
        public SubscriptionStatus SubscriptionStatus { get; set; } // مثلا: Active, Expired

        [BindNever] 
        public ICollection<Student> Students { get; set; }
     
    }

}
