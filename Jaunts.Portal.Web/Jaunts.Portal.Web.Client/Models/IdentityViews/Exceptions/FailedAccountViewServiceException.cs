// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions
{
    public class FailedAccountViewServiceException : Xeption
    {
        public FailedAccountViewServiceException(Exception innerException)
            : base(message: "Failed Account view service error occurred, please contact support", innerException)
        { }
    }
}
