// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Brokers.DateTimes;
using Jaunts.Portal.Web.Client.Brokers.Loggings;
using Jaunts.Portal.Web.Client.Brokers.Navigations;
using Jaunts.Portal.Web.Client.Models.Identity;
using Jaunts.Portal.Web.Client.Models.IdentityViews;
using Jaunts.Portal.Web.Client.Models.UserAccountDetailsViews;
using Jaunts.Portal.Web.Client.Services.Foundations.Identity;
using Jaunts.Portal.Web.Client.Services.Foundations.Users;

namespace Jaunts.Portal.Web.Client.Services.Views.IdentityViews
{
    public partial class IdentityViewService : IIdentityViewService
    {
        private readonly IIdentityService identityService;
        private readonly IUserService userService;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly INavigationBroker navigationBroker;
        private readonly ILoggingBroker loggingBroker;

        public IdentityViewService(
            IIdentityService identityService,
            IUserService userService,
            IDateTimeBroker dateTimeBroker,
            INavigationBroker navigationBroker,
            ILoggingBroker loggingBroker)
        {
            this.identityService = identityService;
            this.userService = userService;
            this.dateTimeBroker = dateTimeBroker;
            this.navigationBroker = navigationBroker;
            this.loggingBroker = loggingBroker;
        }

        public void NavigateTo(string route) =>
        TryCatch(() =>
        {
            ValidateRoute(route);
            this.navigationBroker.NavigateTo(route);
        });


        private SignUp MapToIdentity(SignUpView userCredentialsView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTimeOffset();

            return new SignUp
            {
               Email = userCredentialsView.Email,
               FirstName = userCredentialsView.FirstName,
               LastName = userCredentialsView.LastName,
               Password = userCredentialsView.Password,
               PhoneNumber = userCredentialsView.PhoneNumber,
               Username = userCredentialsView.Username,
               CreatedDate = currentDateTime,
               Id = Guid.NewGuid(),
               UpdatedDate = currentDateTime,

            };
        }

        private ResetPassword MapToIdentity(ResetPasswordView resetPasswordView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTimeOffset();

            return new ResetPassword
            {
                Email = resetPasswordView.Email,
                Password = resetPasswordView.Password,
                Token = resetPasswordView.Token,
            };
        }

        private LoginCredentials MapToIdentity(SignInView loginView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTimeOffset();

            return new LoginCredentials
            {
                UsernameOrEmail = loginView.UsernameOrEmail,
                Password = loginView.Password,
            };
        }
        public ValueTask<UserAccountDetailsResponse> RegisterUserAsync(SignUpView userCredentialsView) =>
        TryCatch(async () =>
        {
            ValidateIdentityView(userCredentialsView);
            SignUp ride = MapToIdentity(userCredentialsView);
            return await this.identityService.RegisterUserAsync(ride);
        });

        public ValueTask<UserAccountDetailsResponse> LogInAsync(SignInView loginView) =>
        TryCatch(async () =>
        {
            ValidateIdentityView(loginView);
            LoginCredentials request = MapToIdentity(loginView);
            return await this.identityService.LogInAsync(request);
        });

        public ValueTask<bool> ResetPasswordAsync(ResetPasswordView resetPasswordView) =>
        TryCatch(async () =>
        {
            ValidateIdentityView(resetPasswordView);
            ValidateIdentityView(resetPasswordView.Password,resetPasswordView.ConfirmPassword);
            ResetPassword request = MapToIdentity(resetPasswordView);
            return await this.identityService.ResetPasswordAsync(request);
        });

        public ValueTask<bool> ForgotPasswordAsync(string email) =>
        TryCatch(async () =>
        {
            ValidateString(email);
            return await this.identityService.ForgotPasswordAsync(email);
        });

        public ValueTask<UserAccountDetailsResponse> EmailConfirmationAsync(string token, string email) =>
        TryCatch(async () =>
        {
            ValidateString(token);
            ValidateString(email);
            return await this.identityService.EmailConfirmationAsync(token,email);
        });

        public ValueTask<UserAccountDetailsResponse> LoginWithOtpAsync(string code, string userNameOrEmail) =>
        TryCatch(async () =>
        {
            ValidateString(code);
            ValidateString(userNameOrEmail);
            return await this.identityService.OtpLoginAsync(code, userNameOrEmail);
        });

        public ValueTask<UserAccountDetailsResponse> EnableUserTwoFactorAsync(Guid id) =>
        TryCatch(async () =>
        {
            ValidateGuid(id);
            return await this.identityService.EnableUserTwoFactorAsync(id);
        });

        private static Func<UserAccountDetailsResponse, UserAccountDetailsView> AsUserAccountDetailsView =>
            UserIdentityDetails => new UserAccountDetailsView
            {
                Email = UserIdentityDetails.Email,
                FirstName = UserIdentityDetails.FirstName,
                Id = UserIdentityDetails.Id,
                LastName = UserIdentityDetails.LastName,
                Token = UserIdentityDetails.Token,
                Role = UserIdentityDetails.Role,
                TwoFactorEnabled = UserIdentityDetails.TwoFactorEnabled,
                Username = UserIdentityDetails.Username,
                EmailConfirmed = UserIdentityDetails.EmailConfirmed
            };
    }
}
