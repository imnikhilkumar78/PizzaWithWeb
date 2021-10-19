using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserPizzaAPI.Models;

namespace UserPizzaAPI.Services
{
    public class UserService
    {
        private readonly UserContext _context;
        private readonly ITokenService _tokenService;

        public UserService(UserContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public UserDTO Register(UserDTO userDTO)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var user = new User()
                {
                    UserEmail = userDTO.Id,
                    Name=userDTO.Name,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                    PasswordSalt = hmac.Key,
                    Address=userDTO.Address,
                    Phone=userDTO.Phone

                };

                _context.Users.Add(user);
                _context.SaveChanges();
                userDTO.jwtToken = _tokenService.CreateToken(userDTO);
                userDTO.Password = "";
                return userDTO;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

        public UserDTO Login(UserDTO userDTO)
        {
            try
            {
                var myUser = _context.Users.SingleOrDefault(u => u.UserEmail == userDTO.Id);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    userDTO.jwtToken = _tokenService.CreateToken(userDTO);
                    userDTO.Password = "";
                    return userDTO;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
