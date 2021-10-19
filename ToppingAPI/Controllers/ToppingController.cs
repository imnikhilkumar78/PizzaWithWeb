using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToppingsAPI.Models;
using ToppingsAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToppingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private readonly ToppingService _service;
        

        public ToppingController(ToppingService toppingService)
        {
            _service = toppingService;
        }
        // GET: api/<ToppingController>
        [HttpGet]
        public IEnumerable<Topping> Get()
        {
            return _service.GetAll();
        }

        // GET api/<ToppingController>/5
        [HttpGet("{id}")]
        public Topping Get(int id)
        {
            return _service.get(id);
        }
        // POST api/<ToppingController>
       
    }
}
