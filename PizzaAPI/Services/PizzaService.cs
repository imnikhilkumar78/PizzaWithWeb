using PizzaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }
        public ICollection<Pizza> GetAll()
        {
            IList<Pizza> pizza = _context.pizzas.ToList();
            if (pizza.Count > 0)
                return pizza;
            else
                return null;
        }
        public Pizza get(int id)
        {
            return _context.pizzas.FirstOrDefault(u => u.PizzaId == id);
        }
    }
}
