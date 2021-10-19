using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PizzaApplication.Models;
using PizzaApplication.Models;
using PizzaApplication.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaApplication.Controllers
{
    public class OrderController : Controller
    {
        private ILogger<OrderController> _logger;
        private readonly OrderService _ORepo;
        private readonly PizzaService _PRepo;
        private readonly ToppingService _TRepo;

        public OrderController(ILogger<OrderController> logger, OrderService ORepo, PizzaService PRepo, ToppingService TRepo)
        {
            _logger = logger;
            _ORepo = ORepo;
            _PRepo = PRepo;
            _TRepo = TRepo;
        }

        // POST api/<OrderController>
        [Route("AddOrder")]
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] UserDTO userDto)
        {
            Debug.WriteLine(" ===> Post Method : AddOrder ");
            if (userDto is null)
                return BadRequest();

            var newOrder = await _ORepo.AddOrder(userDto, TempData.Peek("Token").ToString());
            if (newOrder != null)
                return Ok(newOrder);
            return BadRequest("Not able to register");

        }

        /*[Route("GetOrder")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ORepo.GetAll(TempData.Peek("Token").ToString()));
        }*/

        [Route("summary")]
        [HttpGet]
        public IActionResult summary()
        {
            ViewBag.Status = "Summary";
            SummaryDTO summary = new SummaryDTO();
            OrderSummaryDTO summaryDto =JsonConvert.DeserializeObject<OrderSummaryDTO> (_ORepo.summary());
            _logger.LogInformation(summaryDto.Status);

            summary.OrderId = summaryDto.OrderId;
            summary.UserId = summaryDto.UserId;
            summary.DeliveryCharge = summaryDto.DeliveryCharge;
            summary.Total = summaryDto.Total;
            summary.Status = summaryDto.Status;

            summary.PizzaDic = new Dictionary<int, PizzaDTO>();
            summary.ToppingDic = new Dictionary<int, ToppingDTO>();
            summary.ItemIds = summaryDto.ItemIds;


            ICollection<PizzaDTO> PizzaDto = _PRepo.GetAll(TempData.Peek("Token").ToString());
            ICollection<ToppingDTO> ToppingDto = _TRepo.GetAll(TempData.Peek("Token").ToString());


            if (summaryDto.Pizzas is not null)
            {
                foreach (var item in summaryDto.Pizzas)
                    summary.PizzaDic.Add(item.Key, PizzaDto.FirstOrDefault(pizza => pizza.PizzaId == item.Value));
                    //summary.Pizzas.AddRange(PizzaDto.Where(p => p.PizzaId == item.Value).ToList());

                if (summaryDto.Toppings is not null)
                    foreach (var item in summaryDto.Toppings)
                        summary.ToppingDic.Add(item.Key, ToppingDto.FirstOrDefault(top => top.ToppingId == item.Value));
                //summary.Toppings.AddRange(ToppingDto.Where(top => top.ToppingId == item.Value).ToList());
            }



            return View(summary);

        }


    }
}
