using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    public class ToppingController : ControllerBase
    {
        private readonly ToppingService _toppingservice;

        public ToppingController(ToppingService toppingService)
        {
            _toppingservice = toppingService;
        }
        // GET: api/<PizzaController>
        [Route("GetTopping")]
        [HttpGet]

        public IEnumerable<ToppingDTO> GetPizza()
        {
            if (_toppingservice.GetAll() != null)
            {
                return _toppingservice.GetAll();
            }
            return null;
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ToppingDTO Get(int id)
        {
            ToppingDTO topping = _toppingservice.Get(id);
            if (topping != null)
            {
                return topping;
            }
            return topping;
        }


    }
}
