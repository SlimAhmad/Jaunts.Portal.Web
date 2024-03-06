using Jaunts.Portal.Web.Client.Models.Identity;

namespace Jaunts.Portal.Web.Client.Brokers.Apis
{
    public partial class ApiBroker
    {
        private const string RegisterRelativeUrl = "api/register";
        private const string LoginRelativeUrl = "api/login";
        private const string ResetPasswordRelativeUrl = "api/account/password/reset";
        private const string ForgottenPasswordRelativeUrl = "api/account/password/forgotten";
        private const string ConfirmEmailRelativeUrl = "api/account/confirm";
        private const string OtpRelativeUrl = "api/account/login/otp";
        private const string TwoFactorRelativeUrl = "api/account/enable/2fa";

        public async ValueTask<UserAccountDetailsResponse> PostRegisterUserAsync(SignUp userCredentials)
        {
            return await PostAsync<SignUp, UserAccountDetailsResponse>(
               relativeUrl: RegisterRelativeUrl,
               content: userCredentials);
        }

        public async ValueTask<UserAccountDetailsResponse> PostLoginAsync(LoginCredentials loginCredentials)
        {
            return await PostAsync<LoginCredentials, UserAccountDetailsResponse>(
               relativeUrl: LoginRelativeUrl,
               content: loginCredentials);
        }

        public async ValueTask<bool> PostResetPasswordAsync(ResetPassword resetPassword)
        {
            return await PostAsync<ResetPassword, bool>(
               relativeUrl: ResetPasswordRelativeUrl,
               content: resetPassword);
        }

        public async ValueTask<bool> PutForgottenPasswordAsync(string email)
        {
            return await PutAsync<ResetPassword, bool>(
               relativeUrl: $"{ForgottenPasswordRelativeUrl}/?email={email}",
               content: null);
        }

        public async ValueTask<UserAccountDetailsResponse> PutConfirmEmailAsync(string token,string email)
        {
            return await PutAsync<ResetPassword, UserAccountDetailsResponse>(
               relativeUrl: $"{ConfirmEmailRelativeUrl}/?token={token}&email{email}",
               content: null);
        }

        public async ValueTask<UserAccountDetailsResponse> PutOtpLoginAsync(string code,string userNameOrEmail)
        {
            return await PutAsync<ResetPassword, UserAccountDetailsResponse>(
               relativeUrl: $"{OtpRelativeUrl}/?code={code}&email{userNameOrEmail}",
               content: null);
        }

        public async ValueTask<UserAccountDetailsResponse> PutEnableTwoFactorAsync(Guid userId)
        {
            return await PutAsync<ResetPassword, UserAccountDetailsResponse>(
               relativeUrl: $"{TwoFactorRelativeUrl}/?id={userId}",
               content: null);
        }

    }
}
