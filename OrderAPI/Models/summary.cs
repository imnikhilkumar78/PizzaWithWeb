using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class summary
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public double? Total { get; set; }
        public double? DeliveryCharge { get; set; }
        public string Status { get; set; }
        public List<OrderDetail> Pizzas { get; set; }
        public List<ToppingDetail> Toppings { get; set; }
    }
}
