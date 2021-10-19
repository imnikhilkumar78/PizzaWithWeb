using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToppingsAPI.Services
{
    public interface IToppingService<K>
    {
        ICollection<K> GetAll();
        K Get(int id);
    }

}
