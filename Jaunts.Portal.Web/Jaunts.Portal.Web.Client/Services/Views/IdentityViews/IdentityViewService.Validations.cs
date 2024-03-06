// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.IdentityViews;
using Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions;

namespace Jaunts.Portal.Web.Client.Services.Views.IdentityViews
{
    public partial class IdentityViewService
    {
        private static void ValidateIdentityView(SignUpView  userCredentialsView)
        {
            if (userCredentialsView is null)
            {
                throw new NullIdentityViewException();
            }
        }

        private static void ValidateIdentityView(SignInView  sigInView)
        {
            if (sigInView is null)
            {
                throw new NullIdentityViewException();
            }
        }

        private static void ValidateIdentityView(ResetPasswordView resetPassword)
        {
            if (resetPassword is null)
            {
                throw new NullIdentityViewException();
            }
        }
        private static void ValidateIdentityView(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                throw new InvalidPasswordIdentityViewException(nameof(ResetPasswordView.Password), confirmPassword);
            }
        }

        private static void ValidateRoute(string route)
        {
            if (IsInvalid(route))
            {
                throw new InvalidIdentityViewException(
                    parameterName: "Route",
                    parameterValue: route);
            }
        }

        private static void ValidateString(string value)
        {
            if (IsInvalid(value))
            {
                throw new InvalidIdentityViewException(
                    parameterName: "Value",
                    parameterValue: value);
            }
        }

        private static void ValidateGuid(Guid id)
        {
            if (IsInvalid(id))
            {
                throw new InvalidIdentityViewException(
                    parameterName: "Id",
                    parameterValue: id);
            }
        }
        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);

        private static bool IsInvalid(Guid id) => id  == Guid.Empty;
    }
}
