﻿

namespace Jaunts.Portal.Web.Client.Models.Identity
{
    /// <summary>
    /// The credentials for  an API client to register on the server 
    /// </summary>
    public class SignUp
    {
        #region Public Properties

        /// <summary>
        /// The users user name
        /// </summary>
        public string Username { get; set; } 

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The users password
        /// </summary>s
        public string Password { get; set; }

        /// <summary>
        /// The users phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }


        #endregion

    }
}
