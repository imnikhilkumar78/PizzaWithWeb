﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPizzaAPI.Models
{
    public class PizzaDTO
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Speciality { get; set; }
        public string IsVeg { get; set; }
        public string Imageurl { get; set; }
    }
}
