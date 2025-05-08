using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Models
{
    public class NotificationRecipient
    {
        [Key]
        public int NotificationRecipientId { get; set; }

        [Required]
        public string NotificationId { get; set; }
        public Notification Notification { get; set; }

        public bool DeliveryByGmail { get; set; }
        public bool IsDelivered { get; set; }
    }

}
