using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public class OrderSummaryService
    {
        private readonly OrderContext _context;
        private readonly OrderRepo _order;
        private readonly OrderDetailRepo _orderdetail;
        private readonly ToppingDetailRepo _toppingdetail;
      
        public OrderSummaryService(OrderContext context, OrderRepo order, OrderDetailRepo orderDetail, ToppingDetailRepo toppingDetail)
        {
            _context = context;
            _order = order;
            _orderdetail = orderDetail;
            _toppingdetail = toppingDetail;
        }

        public OrderSummaryDTO summary()
        {
            OrderSummaryDTO summaryDTO = new OrderSummaryDTO();
            Order order = _context.Orders.OrderBy(o => o.OrderId).Last();
            if (order is null)
                return null;
            else
            {
                summaryDTO.UserId = order.UserId;
                summaryDTO.OrderId = order.OrderId;
                summaryDTO.Total = order.Total;
                summaryDTO.DeliveryCharge = order.DeliveryCharge;
                summaryDTO.Status = order.Status;

                summaryDTO.Pizzas = new Dictionary<int, int>();
                summaryDTO.Toppings = new Dictionary<int, int>();
                summaryDTO.ItemIds = new Dictionary<int, int>();


                // summaryDTO.Toppings = new List<ToppingDetail>();
                List<OrderDetail> pizzaList  = _context.OrderDetails.Where(od => od.OrderId==order.OrderId).ToList();

                foreach (var item in pizzaList)
                {
                    summaryDTO.Pizzas.Add(item.ItemId, item.PizzaId);
                    List<ToppingDetail> toppingList = _context.ToppingDetails.Where(od => od.ItemId == item.ItemId).ToList();
                    foreach (var topItem in toppingList)
                    {
                        summaryDTO.Toppings.Add(topItem.toppingDetailId, topItem.ToppingId);
                        summaryDTO.ItemIds.Add(topItem.toppingDetailId, topItem.ItemId);
                    }

                }


                //  foreach (var item in summaryDTO.Pizzas)
              //      summaryDTO.Toppings.AddRange(_context.ToppingDetails.Where(od => od.ItemId == item.ItemId).ToList());
                


            }
            return summaryDTO;
        }
    }
}
