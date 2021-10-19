using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPizzaAPI.Models
{
    public class OrderDetailDTO
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual OrderDTO Order { get; set; }
    }
}
