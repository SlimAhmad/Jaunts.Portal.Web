// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Identity;
using Jaunts.Portal.Web.Client.Models.Identity.Exceptions;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Identity
{
    public partial class IdentityService
    {
        private void ValidateUserOnRegister(SignUp api)
        {
            ValidateRegisterUserIsNull(api);

            Validate(
                (Rule: IsInvalid(api.FirstName), Parameter: nameof(SignUp.FirstName)),
                (Rule: IsInvalid(api.LastName), Parameter: nameof(SignUp.LastName)),
                (Rule: IsInvalid(api.PhoneNumber), Parameter: nameof(SignUp.PhoneNumber)),
                (Rule: IsInvalid(api.Username), Parameter: nameof(SignUp.Username)),
                (Rule: IsInvalid(api.Email), Parameter: nameof(SignUp.Email)));



        }

        private void ValidateResetPassword(ResetPassword resetPassword)
        {
            ValidateResetPasswordIsNull(resetPassword);

            Validate(
               (Rule: IsInvalid(resetPassword.Password), Parameter: nameof(ResetPassword.Password)),
               (Rule: IsInvalid(resetPassword.Token), Parameter: nameof(ResetPassword.Token)));


        }



        private void ValidateUserOnLogin(LoginCredentials request)
        {
            ValidateUserOnLoginIsNull(request);

            Validate(
               (Rule: IsInvalid(request), Parameter: nameof(LoginCredentials.Password)),
               (Rule: IsInvalid(request.UsernameOrEmail), Parameter: nameof(LoginCredentials.UsernameOrEmail)));
        }

        public void ValidateUserId(Guid userId) =>
             Validate((Rule: IsInvalid(userId), Parameter: nameof(UserAccountDetailsResponse)));

        public void ValidateText(string text) =>
             Validate((Rule: IsInvalid(text), Parameter: nameof(ForgotPasswordResponse)));

        public void ValidateUserProfileDetails(string text) =>
             Validate((Rule: IsInvalid(text), Parameter: nameof(UserAccountDetailsResponse)));


        private static void ValidateRegisterUserIsNull(SignUp api)
        {
            if (api is null)
            {
                throw new NullAccountException();
            }
        }

        private static void ValidateResetPasswordIsNull(ResetPassword resetPassword)
        {
            if (resetPassword is null)
            {
                throw new NullAccountException();
            }
        }

        private static void ValidateUserOnLoginIsNull(LoginCredentials request)
        {
            if (request is null)
            {
                throw new NullAccountException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static dynamic IsInvalidUser(object @object) => new
        {
            Condition = @object is null,
            Message = "User not found"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };


        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private dynamic IsNotValidPassword(bool password) => new
        {
            Condition = password is false,
            Message = "Invalid password or email"
        };

        private dynamic IsInvalidCode(bool code) => new
        {
            Condition = code is false,
            Message = "Invalid OTP code"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAccountException = new InvalidAccountException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAccountException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAccountException.ThrowIfContainsErrors();
        }
    }
}
