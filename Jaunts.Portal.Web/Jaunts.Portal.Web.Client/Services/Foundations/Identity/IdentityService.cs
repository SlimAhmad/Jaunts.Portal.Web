// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Brokers.Apis;
using Jaunts.Portal.Web.Client.Brokers.Loggings;
using Jaunts.Portal.Web.Client.Models.Identity;
using Jaunts.Portal.Web.Client.Models.Rides;
using Newtonsoft.Json.Linq;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Identity
{
    public partial class IdentityService : IIdentityService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public IdentityService(
            IApiBroker apiBroker,
            ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<UserAccountDetailsResponse> EmailConfirmationAsync(string token, string email) =>
        TryCatch(async () =>
        {
            ValidateText(email);
            ValidateText(token);
            return await this.apiBroker.PutConfirmEmailAsync(token,email);
        });

        public ValueTask<UserAccountDetailsResponse> EnableUserTwoFactorAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidateUserId(id);
            return await this.apiBroker.PutEnableTwoFactorAsync(id);
        });

        public ValueTask<bool> ForgotPasswordAsync(string email) =>
        TryCatch(async () =>
        {
            ValidateText(email);
            return await this.apiBroker.PutForgottenPasswordAsync(email);
        });

        public ValueTask<UserAccountDetailsResponse> LogInAsync(LoginCredentials loginCredentials) =>
        TryCatch(async () =>
        {
            ValidateUserOnLogin(loginCredentials);
            return await this.apiBroker.PostLoginAsync(loginCredentials);
        });

        public ValueTask<UserAccountDetailsResponse> OtpLoginAsync(string code, string userNameOrEmail) =>
        TryCatch(async () =>
        {
            ValidateText(code);
            ValidateText(userNameOrEmail);
            return await this.apiBroker.PutConfirmEmailAsync(code, userNameOrEmail);
        });

        public ValueTask<UserAccountDetailsResponse> RegisterUserAsync(SignUp userCredentials) =>
        TryCatch(async () =>
        {
            ValidateUserOnRegister(userCredentials);
            return await this.apiBroker.PostRegisterUserAsync(userCredentials);
        });

        public ValueTask<bool> ResetPasswordAsync(ResetPassword resetPassword) =>
        TryCatch(async () =>
        {
            ValidateResetPassword(resetPassword);
            return await this.apiBroker.PostResetPasswordAsync(resetPassword);
        });
    }
}
