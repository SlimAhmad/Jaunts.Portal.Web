using Jaunts.Portal.Web.Client.Models.Identity;

namespace Jaunts.Portal.Web.Client.Brokers.Apis
{
    public partial interface IApiBroker
    {
         ValueTask<UserAccountDetailsResponse> PostRegisterUserAsync(SignUp userCredentials);
         ValueTask<UserAccountDetailsResponse> PostLoginAsync(LoginCredentials loginCredentials);
         ValueTask<bool> PostResetPasswordAsync(ResetPassword resetPassword);
         ValueTask<bool> PutForgottenPasswordAsync(string email);
         ValueTask<UserAccountDetailsResponse> PutConfirmEmailAsync(string token, string email);
         ValueTask<UserAccountDetailsResponse> PutOtpLoginAsync(string code, string userNameOrEmail);
         ValueTask<UserAccountDetailsResponse> PutEnableTwoFactorAsync(Guid userId);
    }
}
