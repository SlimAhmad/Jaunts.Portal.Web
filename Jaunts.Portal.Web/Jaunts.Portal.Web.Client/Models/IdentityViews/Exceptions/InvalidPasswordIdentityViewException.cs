// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions
{
    public class InvalidPasswordIdentityViewException : Exception
    {
        public InvalidPasswordIdentityViewException(string parameterName, object parameterValue)
            : base($"Invalid password View error occurred. " +
                 $"parameter name: {parameterName}, " +
                 $"parameter value: {parameterValue}")
        { }
    }
}
