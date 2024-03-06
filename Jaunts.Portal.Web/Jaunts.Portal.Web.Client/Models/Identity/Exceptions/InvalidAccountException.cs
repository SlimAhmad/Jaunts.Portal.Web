// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Collections;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Identity.Exceptions
{
    public class InvalidAccountException : Xeption
    {
        public InvalidAccountException()
            : base(message: "Invalid Account. correct the errors and try again.")
        { }

        public InvalidAccountException(Exception innerException, IDictionary data)
            : base(message: "Invalid Account error occurred. please correct the errors and try again.",
                  innerException,
                  data)
        { }
    }
}
