// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class NotFoundAccountException : Xeption
    {
        public NotFoundAccountException(Exception innerException)
            : base(message: "Not found Account error occurred, please try again.",
                  innerException)
        { }
    }
}
