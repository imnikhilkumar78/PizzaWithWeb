using OrderApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public class ToppingDetailRepo : IToppingDetailRepo<ToppingDetail>
    {
        private readonly OrderContext _context;


        public ToppingDetailRepo(OrderContext context)
        {
            _context = context;
        }

        public ToppingDetail AddTopping( ToppingDTO toppingDto)
        {
          
           ToppingDetail toppingDetail = new ToppingDetail();
            try
            {
                OrderDetail orderDetail = _context.OrderDetails.OrderBy(od => od.ItemId).Last();
                if (orderDetail is null) return null;
                toppingDetail.ItemId = orderDetail.ItemId;
                toppingDetail.ToppingId = toppingDto.ToppingId;


                Order order = _context.Orders.OrderBy(o => o.OrderId).Last();
                if (order is null) return null;
                order.Total += toppingDto.Price;

                _context.Orders.Update(order);
                _context.ToppingDetails.Add(toppingDetail);
                _context.SaveChanges();


            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return toppingDetail;

        }
    }
}
