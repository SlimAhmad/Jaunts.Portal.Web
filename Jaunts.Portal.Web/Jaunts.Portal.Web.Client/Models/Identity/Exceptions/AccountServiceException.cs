// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class AccountServiceException : Xeption
    {
        public AccountServiceException(Xeption innerException)
            : base(message: "Account service error occurred, contact support.",
                  innerException)
        { }
    }
}
