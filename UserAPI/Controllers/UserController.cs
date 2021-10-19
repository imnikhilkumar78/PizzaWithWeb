using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPizzaAPI.Models;
using UserPizzaAPI.Services;

namespace UserPizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService services)
        {
            _service = services;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var userDTO = _service.Register(user);
            if (userDTO != null)
                return userDTO;
            return BadRequest("Not Able to Register");
        }
        [Route("Login")]
        [HttpPost]

        public async Task<ActionResult<UserDTO>> Put([FromBody] UserDTO user)
        {
            var userDTO = _service.Login(user);
            if (userDTO != null)
                return Ok(userDTO);
            return BadRequest("Not Working");

        }
    }
}
