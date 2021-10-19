using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public interface IOrderRepo<K>
    {
        Task<IEnumerable<K>> GetAll();


        K CreateOrder(UserDTO userDTO);

        K UpdateDeliveryCharge();




    }
}
