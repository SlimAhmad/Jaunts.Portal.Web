﻿namespace Jaunts.Portal.Web.Client.Models.Identity
{
    /// <summary>
    /// The credentials for an API client to log into the server and receive a token back
    /// </summary>
    public class LoginOtp
    {
        #region Public Properties

        /// <summary>
        /// The users user name or email
        /// </summary>
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        public string Code { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginOtp()
        {

        }

        #endregion
    }
}
