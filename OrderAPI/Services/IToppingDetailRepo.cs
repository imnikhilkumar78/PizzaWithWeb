using OrderApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public interface IToppingDetailRepo<K>
    {
        K AddTopping(ToppingDTO toppingDto); 
    }
}
