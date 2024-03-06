// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.RideViews.Exceptions
{
    public class RideViewValidationException : Exception
    {
        public RideViewValidationException(Exception innerException)
            : base($"Ride View validation error occurred, try again.", innerException) { }
    }
}
