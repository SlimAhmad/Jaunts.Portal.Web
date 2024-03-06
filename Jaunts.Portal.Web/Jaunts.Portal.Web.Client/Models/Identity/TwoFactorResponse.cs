using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaunts.Portal.Web.Client.Models.Identity
{
    public class TwoFactorResponse<T>
    {

        public bool Successful => ErrorMessage == null;
        public string ErrorMessage { get; set; }
    }
}
