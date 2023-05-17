using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VICMAPI.Models;

namespace VICMAPI.Service
{
    public interface ILoginService
    {
        UserCreds Login(UserCreds userCreds);
       UserCreds Register(Customers user);
    }
}
