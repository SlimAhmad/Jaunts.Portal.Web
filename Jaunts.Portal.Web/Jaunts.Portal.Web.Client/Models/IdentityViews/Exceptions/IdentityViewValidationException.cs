// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions
{
    public class IdentityViewValidationException : Exception
    {
        public IdentityViewValidationException(Exception innerException)
            : base($"Account View validation error occurred, try again.", innerException) { }
    }
}
