// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.RideRegistrationComponents.Exceptions
{
    public class RideRegistrationComponentException : Exception
    {
        public RideRegistrationComponentException(Exception innerException)
            : base("Error occurred, contact support", innerException)
        {

        }
    }
}
