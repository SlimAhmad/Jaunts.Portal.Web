// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class FailedAccountServiceException : Xeption
    {
        public FailedAccountServiceException(Exception innerException)
            : base(message: "Failed Account service error occurred, contact support.",
                  innerException)
        { }
    }
}
