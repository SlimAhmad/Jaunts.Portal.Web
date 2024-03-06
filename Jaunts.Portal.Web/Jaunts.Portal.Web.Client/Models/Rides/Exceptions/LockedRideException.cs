// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class LockedRideException : Xeption
    {
        public LockedRideException(Exception innerException)
            : base(message: "Locked Ride error occurred, please try again later.",
                  innerException)
        { }
    }
}
