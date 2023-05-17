using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VICMAPI.Models;

namespace VICMAPI.Service
{
     public interface IUserService
    {
        List<Customers> GetAllUser();
        Customers AddUser(Customers user);
    }
}
