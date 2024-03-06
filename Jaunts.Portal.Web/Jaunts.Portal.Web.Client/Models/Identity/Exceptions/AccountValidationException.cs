// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class AccountValidationException : Xeption
    {
        public AccountValidationException(Exception innerException)
            : base(message: "Account validation error occurred, please try again.",
                  innerException)
        { }
    }
}
