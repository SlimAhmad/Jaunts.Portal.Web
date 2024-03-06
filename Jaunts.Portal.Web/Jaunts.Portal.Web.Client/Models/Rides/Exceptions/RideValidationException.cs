// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class RideValidationException : Xeption
    {
        public RideValidationException(Exception innerException)
            : base(message: "Ride validation error occurred, please try again.",
                  innerException)
        { }
    }
}
