using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPizzaAPI.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public double? Total { get; set; }
        public double? DeliveryCharge { get; set; }
        public string Status { get; set; }
    }
}
