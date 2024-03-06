// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;

namespace Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions
{
    public class IdentityViewDependencyException : Exception
    {
        public IdentityViewDependencyException(Exception innerException)
            : base("Account view dependency error occurred, contact support.", innerException) { }
    }
}
