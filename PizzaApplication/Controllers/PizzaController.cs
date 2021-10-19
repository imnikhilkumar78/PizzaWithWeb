using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaApplication.Models;
using PizzaApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Controllers
{
    public class PizzaController : Controller
    {
        /*private readonly PizzaService _service;

        public PizzaController(PizzaService pizzaService)
        {
            _service = pizzaService;
        }
        public IActionResult GetAll()
        {
            List<string> PizzaList1 = new List<string>();
            if (TempData["token"] != null)
            {
                string PizzaList = _service.GetAll(TempData.Peek("token").ToString());
                ViewBag.Pizza = PizzaList;
                PizzaList1 = PizzaList.Split('}').ToList();
                
              
                
            }
            var PizzaList2 = new PizzaDTO()
            {
                Pizza = PizzaList1
            };

            return View(PizzaList2);
        }*/
        private ILogger<PizzaController> _logger;
        private readonly PizzaService _PRepo;
        private readonly OrderService _ORepo;

        public PizzaController(ILogger<PizzaController> logger, PizzaService PRepo,OrderService Orepo)
        {
            _logger = logger;
            _PRepo = PRepo;
            _ORepo = Orepo;
        }
        public IActionResult GetAll()
        {
            _logger.LogInformation(TempData.Peek("Token").ToString());
            //ViewData["Pizza"] = _PRepo.Get(ID);
            ICollection<PizzaDTO> dTOs = _PRepo.GetAll(TempData.Peek("Token").ToString());
            return View(dTOs);
        }

        [HttpPost]
       public async Task<IActionResult> Select_This(int id)
        {
            ViewBag.Status = "Pizza Added";
            await _ORepo.AddPizza(_PRepo.Get(id, TempData.Peek("Token").ToString()), TempData.Peek("Token").ToString());  /* Calling AddPizza from Orderapi*/
            return View(_PRepo.Get(id, TempData.Peek("Token").ToString()));

        }
        public IActionResult Checkout()
        {
           
            return RedirectToAction("summary", "Order");
        }
        public IActionResult AddPizza()
        {
            return RedirectToAction("GetAll", "Pizza");
        }
        public IActionResult AddTopping()
        {
            return RedirectToAction("GetAll", "Topping");
        }

    }
}
