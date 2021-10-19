using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Services
{
    interface IpizzaService<K>
    {
        ICollection<K> GetAll();
        K Get(int id);
    }
}
