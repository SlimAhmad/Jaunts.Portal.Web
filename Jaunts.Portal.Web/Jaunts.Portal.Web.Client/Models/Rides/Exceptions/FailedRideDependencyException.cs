// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.Rides.Exceptions
{
    public class FailedRideDependencyException : Xeption
    {
        public FailedRideDependencyException(Exception innerException)
            : base(message: "Failed Ride dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
