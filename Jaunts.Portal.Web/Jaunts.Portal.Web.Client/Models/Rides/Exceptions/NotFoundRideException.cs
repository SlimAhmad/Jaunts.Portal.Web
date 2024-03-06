// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class NotFoundRideException : Xeption
    {
        public NotFoundRideException(Exception innerException)
            : base(message: "Not found Ride error occurred, please try again.",
                  innerException)
        { }
    }
}
