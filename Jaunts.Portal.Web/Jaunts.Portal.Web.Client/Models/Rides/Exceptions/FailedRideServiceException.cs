// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class FailedRideServiceException : Xeption
    {
        public FailedRideServiceException(Exception innerException)
            : base(message: "Failed Ride service error occurred, contact support.",
                  innerException)
        { }
    }
}
