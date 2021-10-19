using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPizzaAPI.Models
{
    public class ToppingDTO
    {
        public int ToppingId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
