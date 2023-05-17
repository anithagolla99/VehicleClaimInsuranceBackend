using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VICMAPI.Models;

namespace VICMAPI.Service
{
    public class UserService :IUserService
    {
        private readonly VICMS_81258Context _vICMS_81258Context;
        public UserService(VICMS_81258Context vICMS_81258Context)
        {
            _vICMS_81258Context = vICMS_81258Context;
        }
        public Customers AddUser(Customers user)
        {
            var result = _vICMS_81258Context.Customers.Add(user);
            _vICMS_81258Context.SaveChanges();
            if (result != null)
                return user;

            return null;
            
        }

        public List<Customers> GetAllUser()
        {
            return _vICMS_81258Context.Customers.ToList();
        }
    }
}
