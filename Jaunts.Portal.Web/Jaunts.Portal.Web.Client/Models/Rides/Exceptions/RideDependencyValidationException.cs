// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class RideDependencyValidationException : Xeption
    {
        public RideDependencyValidationException(Xeption innerException)
            : base(message: "Ride dependency validation error occurred, please try again.",
                  innerException)
        { }
    }
}
