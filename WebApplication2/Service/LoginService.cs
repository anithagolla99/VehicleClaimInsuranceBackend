using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VICMAPI.Models;

namespace VICMAPI.Service
{
    public class LoginService : ILoginService
    {
        private readonly ITokenGeneration _tokenGeneration;
        private readonly IUserService _userService;

        public LoginService(ITokenGeneration tokenGeneration, IUserService userService)
        {

            _tokenGeneration = tokenGeneration;
            _userService = userService;
        }
        public UserCreds Login(UserCreds userCreds)
        {
            var user = _userService.GetAllUser().FirstOrDefault(u => u.CustomerEmail == userCreds.CustomerEmail);
            if (user != null)
            {
                if (user.CustomerPassword != userCreds.Password)
                {
                    return null;
                }
                userCreds.Password = user.CustomerPassword;
                userCreds.Token = _tokenGeneration.GenerateToken(userCreds);
                return userCreds;
            }
            return null;
        }

        public UserCreds Register(Customers customer)
        {
            var Customers = _userService.GetAllUser().FirstOrDefault(u => u.CustomerEmail == customer.CustomerEmail);
            if (Customers == null)
            {
                Customers customers = _userService.AddUser(customer);
            }
           if(Customers != null)
            {
                return new UserCreds
                {
                    CustomerEmail = Customers.CustomerEmail,
                    Token = _tokenGeneration.GenerateToken(new UserCreds { CustomerEmail = Customers.CustomerEmail })
                };
                
            }
            return null;

        }

        
    }
}
