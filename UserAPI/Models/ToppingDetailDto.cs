using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPizzaAPI.Models
{
    public class ToppingDetailDto
    {
        public int toppingDetailId { get; set; }
        public int ItemId { get; set; }
        public int ToppingId { get; set; }
    }
}
