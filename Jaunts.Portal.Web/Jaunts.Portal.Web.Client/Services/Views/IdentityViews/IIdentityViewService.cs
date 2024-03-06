// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Identity;
using Jaunts.Portal.Web.Client.Models.IdentityViews;

namespace Jaunts.Portal.Web.Client.Services.Views.IdentityViews
{
    public interface IIdentityViewService
    {
        ValueTask<UserAccountDetailsResponse> RegisterUserAsync(
                    SignUpView  userCredentialsView);

        ValueTask<UserAccountDetailsResponse> LogInAsync(
             SignInView loginView);

        ValueTask<bool> ResetPasswordAsync(
           ResetPasswordView  resetPasswordView);

        ValueTask<bool> ForgotPasswordAsync(
             string email);

        ValueTask<UserAccountDetailsResponse> EmailConfirmationAsync(
            string token,
            string email);

        ValueTask<UserAccountDetailsResponse> LoginWithOtpAsync(
            string code,
            string userNameOrEmail);

        ValueTask<UserAccountDetailsResponse> EnableUserTwoFactorAsync(Guid id);

        void NavigateTo(string route);
    }
}
