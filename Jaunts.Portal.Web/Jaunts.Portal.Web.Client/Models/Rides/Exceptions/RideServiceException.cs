// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class RideServiceException : Xeption
    {
        public RideServiceException(Xeption innerException)
            : base(message: "Ride service error occurred, contact support.",
                  innerException)
        { }
    }
}
