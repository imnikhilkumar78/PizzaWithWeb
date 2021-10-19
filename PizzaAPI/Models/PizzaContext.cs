using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Models
{
    public class PizzaContext:DbContext
    {
        public PizzaContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Pizza> pizzas { get; set; }
    }
}
