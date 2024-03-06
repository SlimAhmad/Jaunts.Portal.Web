// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class FailedAccountDependencyException : Xeption
    {
        public FailedAccountDependencyException(Exception innerException)
            : base(message: "Failed Account dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
