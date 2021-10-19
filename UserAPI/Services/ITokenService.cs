using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPizzaAPI.Models;

namespace UserPizzaAPI.Services
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
    }
}
