using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VICMAPI.Service
{
     public interface ITokenGeneration
    {
        string GenerateToken(UserCreds userCreds);
    }
}
