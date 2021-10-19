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
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        // GET: api/<PizzaController>
        [Route("GetPizza")]
        [HttpGet]

        public IEnumerable<PizzaDTO> GetPizza()
        {
            if (_pizzaService.GetAll() != null)
            {
                return _pizzaService.GetAll();
            }
            return null;
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public PizzaDTO Get(int id)
        {
            PizzaDTO pizza = _pizzaService.Get(id);
            if (pizza != null)
            {
                return pizza;
            }
            return pizza;
        }


    }
}
