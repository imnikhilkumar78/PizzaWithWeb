using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.Services;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderApi.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepo _orderRepo;
        private readonly OrderDetailRepo _orderDetailRepo;
        private readonly ToppingDetailRepo _toppingDetailRepo;
        private readonly OrderSummaryService _ordersummaryservice;

        //private IEnumerable<Employee> employee;

        public OrderController(OrderRepo orderRepo, OrderDetailRepo orderDetailRepo, ToppingDetailRepo toppingDetailRepo,OrderSummaryService orderSummaryService)
        {
            //employee = new();
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
            _toppingDetailRepo = toppingDetailRepo;
            _ordersummaryservice = orderSummaryService;
        }

        [HttpGet]

        public async Task<IActionResult> GetOrders()
        {

            try
            {
                var orders = await _orderRepo.GetAll();

                return Ok(orders);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }


        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var result = await _orderRepo.GetOrderById(id);

                if (result == null) return NotFound();
                
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET api/<OrderController>/5
        [HttpGet, Route("summary")]
        public async Task<ActionResult<OrderSummaryDTO>> GetSummary()
        {
            try
            {
                _orderRepo.UpdateDeliveryCharge();
                var result = _ordersummaryservice.summary();

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] UserDTO userDto)
        {
            if (userDto is null)
                return BadRequest();

            var newOrder = _orderRepo.CreateOrder(userDto);
            if (newOrder != null)
                return newOrder;
            return BadRequest("Not able to register");

        }

        // POST api/<OrderController>/pizza
        [HttpPost, Route("Pizza")]
        public async Task<ActionResult<OrderDetail>> AddPizza([FromBody] PizzaDTO pizzaDto)
        {

            try 
            {
                if (pizzaDto is null)
                    return BadRequest("Pizza is not selected");
              
                var newOrderDetail = _orderDetailRepo.AddPizza(pizzaDto);
               
                if (newOrderDetail != null)
                {
                    return Ok(newOrderDetail);
                }
            }
            catch (Exception e) 
            {
                Debug.WriteLine(" --- Exception POST Method: "+e.Message);
            }
            return BadRequest("Not able to add Pizza");

        }
        // POST api/<OrderController>/topping
        [HttpPost, Route("Topping")]
        public async Task<ActionResult<ToppingDetail>> AddTopping([FromBody] ToppingDTO toppingDto)
        {
            if (toppingDto is null )
                return BadRequest();

            var newToppingDetail = _toppingDetailRepo.AddTopping( toppingDto);
            if (newToppingDetail != null)
                return newToppingDetail;
            return BadRequest("Not able to add Topping");

        }


        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
