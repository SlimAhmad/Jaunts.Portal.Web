using System.Collections.Generic;

namespace Jaunts.Portal.Web.Client.Models.Identity
{
    /// <summary>
    /// The credentials for an API client to log into the server and receive a token back
    /// </summary>
    public class LoginCredentials
    {
        #region Public Properties
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        #endregion
    }
}
