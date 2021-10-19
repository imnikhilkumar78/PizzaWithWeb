using Microsoft.AspNetCore.Http;
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
    public class ToppingController : Controller
    {
        private ILogger<ToppingController> _logger;
        private readonly ToppingService _TRepo;
        private readonly OrderService _ORepo;

        public ToppingController(ILogger<ToppingController> logger, ToppingService TRepo, OrderService Orepo)
        {
            _logger = logger;
            _TRepo = TRepo;
            _ORepo = Orepo;
        }
        public IActionResult GetAll()
        {
            _logger.LogInformation(TempData.Peek("Token").ToString());
            //ViewData["Pizza"] = _PRepo.Get(ID);
            ICollection<ToppingDTO> dTOs = _TRepo.GetAll(TempData.Peek("Token").ToString());
            return View(dTOs);
        }

        public async Task<IActionResult> Select_This(int id)
        {
            ViewBag.Status = "Topping Added";
            await _ORepo.AddTopping(_TRepo.Get(id, TempData.Peek("Token").ToString()), TempData.Peek("Token").ToString());
            return View(_TRepo.Get(id, TempData.Peek("Token").ToString()));

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

