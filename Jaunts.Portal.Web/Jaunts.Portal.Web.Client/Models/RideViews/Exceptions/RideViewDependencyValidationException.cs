// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.RideViews.Exceptions
{
    public class RideViewDependencyValidationException : Exception
    {
        public RideViewDependencyValidationException(Exception innerException)
            : base("Ride view dependency validation error occurred, try again.", innerException) { }
    }
}
