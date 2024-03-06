// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Collections;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class InvalidRideException : Xeption
    {
        public InvalidRideException()
            : base(message: "Invalid Ride. correct the errors and try again.")
        { }

        public InvalidRideException(Exception innerException, IDictionary data)
            : base(message: "Invalid Ride error occurred. please correct the errors and try again.",
                  innerException,
                  data)
        { }
    }
}
