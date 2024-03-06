// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class LockedAccountException : Xeption
    {
        public LockedAccountException(Exception innerException)
            : base(message: "Locked Account error occurred, please try again later.",
                  innerException)
        { }
    }
}
