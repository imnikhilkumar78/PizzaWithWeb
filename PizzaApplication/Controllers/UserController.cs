using Microsoft.AspNetCore.Mvc;
using PizzaApplication.Models;
using PizzaApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _service;
        private readonly OrderService _oservice;

        public UserController(UserService userServices,OrderService orderService)
        {
            _service = userServices;
            _oservice = orderService;
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            try
            {
                UserDTO user = _service.Login(userDTO);
                if (user != null)
                {
                    TempData["token"] = user.jwtToken;
                    await _oservice.AddOrder(userDTO, TempData.Peek("Token").ToString());  /*Calling the addorder*/
                    return RedirectToAction("GetAll", "Pizza");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserDTO userDTO)
        {
            try
            {
                UserDTO user = _service.Register(userDTO);
                if (user != null)
                {
                    TempData["token"] = user.jwtToken;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {

                return View();
            }
            ViewBag.Error = "Not Registered";
            return View();
        }

    }
}
