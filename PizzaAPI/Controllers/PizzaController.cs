using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using PizzaAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _service;
        //private IEnumerable<Employee> employee;

        public PizzaController(PizzaService pizzaService)
        {
            //employee = new();
            _service = pizzaService;
        }
        // GET: api/<PizzaController>
        [HttpGet]
        public ICollection<Pizza> Get()
        {
            return _service.GetAll();
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public Pizza Get(int id)
        {
            return _service.get(id);
        }

        
    }
}
