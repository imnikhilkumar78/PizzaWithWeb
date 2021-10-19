using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#nullable disable

namespace OrderApi.Models
{
  
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
       
        public int OrderId { get; set; }
        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; set; }
        public double? Total { get; set; }
        public double? DeliveryCharge { get; set; }
        public string Status { get; set; }

        // public virtual User User { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
