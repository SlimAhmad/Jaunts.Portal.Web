// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.RideViews.Exceptions
{
    public class InvalidRideViewException : Exception
    {
        public InvalidRideViewException(string parameterName, object parameterValue)
            : base($"Invalid Ride View error occured. " +
                 $"parameter name: {parameterName}, " +
                 $"parameter value: {parameterValue}")
        { }
    }
}
