// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Identity;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Identity
{
    public interface IIdentityService
    {
        ValueTask<UserAccountDetailsResponse> RegisterUserAsync(
                SignUp registerApiRequest);

        ValueTask<UserAccountDetailsResponse> LogInAsync(
             LoginCredentials loginApiRequest);

        ValueTask<bool> ResetPasswordAsync(
           ResetPassword resetPassword);

        ValueTask<bool> ForgotPasswordAsync(
             string email);

        ValueTask<UserAccountDetailsResponse> EmailConfirmationAsync(
            string token,
            string email);

        ValueTask<UserAccountDetailsResponse> OtpLoginAsync(
            string code,
            string userNameOrEmail);

        ValueTask<UserAccountDetailsResponse> EnableUserTwoFactorAsync(Guid id);
    }
}
