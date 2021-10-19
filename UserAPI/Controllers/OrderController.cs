using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserPizzaAPI.Models;
using UserPizzaAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserPizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _Oservices;

        public OrderController(OrderService orderServices)
        {
            _Oservices = orderServices;
        }

        [HttpGet]

        public async Task<IActionResult> GetOrders()
        {

            try
            {
                var orders = await _Oservices.GetAll();

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
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            try
            {
                var result = _Oservices.Get(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //// GET api/<OrderController>/5
        //[HttpGet, Route("Summary")]
        //public async Task<ActionResult<OrderDTO>> GetSummary(int id)
        //{
        //    try
        //    {
        //        var result = _Oservices.Summary(id);

        //        if (result == null) return NotFound();

        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder([FromBody] UserDTO userDto)
        {
            if (userDto is null)
                return BadRequest();

            var newOrder = await _Oservices.AddOrder(userDto);
            if (newOrder != null)
                return newOrder;
            return BadRequest("Not able to register");

        }

        // POST api/<OrderController>/pizza
        [HttpPost, Route("Pizza")]
        public async Task<ActionResult<OrderDetailDTO>> AddPizza([FromBody] PizzaDTO pizzaDto)
        {

            try
            {
                if (pizzaDto is null)
                    return BadRequest("Pizza is not selected");

                var newOrderDetail = await _Oservices.AddPizza(pizzaDto);

                if (newOrderDetail != null)
                {
                    return Ok(newOrderDetail);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(" --- Exception POST Method: " + e.Message);
            }
            return BadRequest("Not able to add Pizza");

        }

        [HttpPost, Route("Topping")]
        public async Task<ActionResult<OrderDetailDTO>> AddTopping([FromBody] ToppingDTO toppingDto)
        {

            try
            {
                if (toppingDto is null)
                    return BadRequest("Topping is not selected");

                var newOrderDetail = await _Oservices.AddTopping(toppingDto);

                if (newOrderDetail != null)
                {
                    return Ok(newOrderDetail);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(" --- Exception POST Method: " + e.Message);
            }
            return BadRequest("Not able to add topping");

        }
        //// POST api/<OrderController>/topping
        //[HttpPost, Route("Topping")]
        //public async Task<ActionResult<ToppingDetailDTO>> AddTopping([FromBody] ToppingDTO toppingDto)
        //{
        //    if (toppingDto is null)
        //        return BadRequest();

        //    var newToppingDetail = _toppingDetailRepo.AddTopping(toppingDto);
        //    if (newToppingDetail != null)
        //        return newToppingDetail;
        //    return BadRequest("Not able to add Topping");

        //}


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
