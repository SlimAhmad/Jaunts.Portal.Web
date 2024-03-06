// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.RideViews.Exceptions
{
    public class RideViewServiceException : Exception
    {
        public RideViewServiceException(Exception innerException)
            : base("Ride View service error occurred, contact support.", innerException) { }
    }
}
