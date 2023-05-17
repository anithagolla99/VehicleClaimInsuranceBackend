using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VICMAPI.Models;
using VICMAPI.Service;

namespace VICMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly VICMS_81258Context _context;
        private readonly ILoginService _loginService;
        

        public LoginsController( ILoginService loginService)
        {
            
            _loginService = loginService;
            
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<UserCreds> Login([FromBody]UserCreds creds)
        {
            var user = _loginService.Login(creds);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("register")]
        public ActionResult<UserCreds> Register([FromBody] Customers creds)
        {
            var user = _loginService.Register(creds);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();

        }

        
    }
}