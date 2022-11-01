using CAP_Backend_Source.Models;
using CAP_Backend_Source.Modules.Account.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAP_Backend_Source.Services.User.Request
{
    public class CreateAccountRequest
    {
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }

}