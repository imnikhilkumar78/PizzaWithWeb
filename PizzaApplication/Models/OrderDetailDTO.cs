using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Models
{
    public class OrderDetailDTO
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual OrderDTO Order { get; set; }
    }
}
