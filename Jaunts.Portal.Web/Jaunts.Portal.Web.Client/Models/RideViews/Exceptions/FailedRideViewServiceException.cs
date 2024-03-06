﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.RideViews.Exceptions
{
    public class FailedRideViewServiceException : Xeption
    {
        public FailedRideViewServiceException(Exception innerException)
            : base(message: "Failed Ride view service error occurred, please contact support", innerException)
        { }
    }
}
