using Microsoft.EntityFrameworkCore;
using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public class OrderRepo : IOrderRepo<Order>
    {
        private readonly OrderContext _context;


        public OrderRepo(OrderContext context)
        {
            _context = context;
        }


        public Order CreateOrder(UserDTO userDto)
        {
            Order order = new Order();
            try
            {
                order.UserId = userDto.Id;
                order.Status = "In Transit";
                order.Total = 0;
                order.DeliveryCharge = 5;
                _context.Orders.Add(order);
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

            return order;
        }

        public Order UpdateDeliveryCharge()
        {
            Order order = new Order();
            try
            {
                order = _context.Orders.OrderBy(o => o.OrderId).Last();

                double? totalPrice = order.Total;
                if (totalPrice > 25)
                    order.DeliveryCharge = 0;
                else
                    order.DeliveryCharge = 5;

                _context.Orders.Update(order);
                _context.SaveChanges();
                return order;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return order;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            UpdateDeliveryCharge();
            return await _context.Orders
                .FirstOrDefaultAsync(e => e.OrderId == orderId);
        }

       
    }
}
