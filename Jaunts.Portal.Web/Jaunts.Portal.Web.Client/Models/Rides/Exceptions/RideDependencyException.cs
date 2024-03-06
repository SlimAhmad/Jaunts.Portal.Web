// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class RideDependencyException : Xeption
    {
        public RideDependencyException(Xeption innerException)
            : base(message: "Ride dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
