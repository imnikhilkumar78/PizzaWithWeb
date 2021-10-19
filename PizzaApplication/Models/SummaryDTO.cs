using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Models
{
    public class SummaryDTO
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public double? Total { get; set; }
        public double? DeliveryCharge { get; set; }
        public string Status { get; set; }

            
        public Dictionary<int,PizzaDTO> PizzaDic { get; set; }
        public Dictionary<int, ToppingDTO> ToppingDic { get; set; }
        public Dictionary<int, int> ItemIds { get; set; }


    }
}
