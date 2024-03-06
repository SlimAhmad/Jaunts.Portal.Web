using System.Collections.Generic;

namespace Jaunts.Portal.Web.Client.Models.Identity
{

    /// <summary>
    /// The result of a login request or get user profile details request via API
    /// </summary>
    public class UserAccountDetailsResponse
    {
        #region Public Properties

        public Guid Id { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool EmailConfirmed { get; set; }

        #endregion

    }
}
