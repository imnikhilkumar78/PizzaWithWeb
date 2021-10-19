using OrderApi.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public class OrderDetailRepo : IOrderDetailRepo<OrderDetail>
    {
        private readonly OrderContext _context;


        public OrderDetailRepo(OrderContext context)
        {
            _context = context;
        }
        public OrderDetail AddPizza(PizzaDTO pizzaDto)
        {
            OrderDetail orderDetail = new OrderDetail();
           
            try
            {
                Order order = _context.Orders.OrderBy(o => o.OrderId).Last();
                if (order is null) return null; 
                orderDetail.OrderId = order.OrderId;
                orderDetail.PizzaId = pizzaDto.PizzaId;

                order.Total += pizzaDto.Price;

                _context.Orders.Update(order);
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();

            }
            catch (ArgumentException ae)
            {
                Debug.WriteLine(" --- Argument Exception: "+ae.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(" --- Exception: " + e.Message);
            }
           
            return orderDetail;

        }

      

    }
}
