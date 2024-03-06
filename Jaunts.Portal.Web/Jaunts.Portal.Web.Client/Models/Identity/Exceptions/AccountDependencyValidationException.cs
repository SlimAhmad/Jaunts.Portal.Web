// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class AccountDependencyValidationException : Xeption
    {
        public AccountDependencyValidationException(Xeption innerException)
            : base(message: "Account dependency validation error occurred, please try again.",
                  innerException)
        { }
    }
}
