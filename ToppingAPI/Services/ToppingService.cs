using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToppingsAPI.Models;

namespace ToppingsAPI.Services
{
    public class ToppingService
    {
        private readonly ToppingContext _context;

        public ToppingService(ToppingContext context)
        {
            _context = context;
        }
        public ICollection<Topping> GetAll()
        {
            IList<Topping> toppings = _context.toppings.ToList();
            if (toppings.Count > 0)
                return toppings;
            else
                return null;
        }
        public Topping get(int id)
        {
            return _context.toppings.FirstOrDefault(u => u.ToppingId == id);
        }
    }
}
