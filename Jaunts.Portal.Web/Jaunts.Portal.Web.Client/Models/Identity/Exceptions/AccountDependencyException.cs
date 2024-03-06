// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class AccountDependencyException : Xeption
    {
        public AccountDependencyException(Xeption innerException)
            : base(message: "Account dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
