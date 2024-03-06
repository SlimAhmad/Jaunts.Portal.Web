using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaunts.Portal.Web.Client.Models.Identity
{
    public class ResetPassword
    {
        public string Token { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
