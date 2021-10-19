using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToppingsAPI.Models
{
    public class ToppingContext:DbContext
    {
        public ToppingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Topping> toppings { get; set; }
    }
}
