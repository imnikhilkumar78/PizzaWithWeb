using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Speciality { get; set; }
        public string IsVeg { get; set; }
        public string Imageurl { get; set; }
    }
}
