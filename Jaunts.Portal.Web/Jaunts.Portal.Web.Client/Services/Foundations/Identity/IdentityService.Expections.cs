// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Identity;
using Jaunts.Portal.Web.Client.Models.Identity.Exceptions;
using RESTFulSense.WebAssembly.Exceptions;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Identity
{
    public partial class IdentityService
    {
        private delegate ValueTask<UserAccountDetailsResponse> ReturningAccountFunction();
        private delegate ValueTask<Boolean> ReturningBooleanFunction();
        private async ValueTask<UserAccountDetailsResponse> TryCatch(
            ReturningAccountFunction returningAccountFunction)
        {
            try
            {
                return await returningAccountFunction();
            }
            catch (NullAccountException nullAccountException)
            {
                throw CreateAndLogValidationException(nullAccountException);
            }
            catch (InvalidAccountException invalidAccountException)
            {
                throw CreateAndLogValidationException(invalidAccountException);
            }
            catch (HttpRequestException httpRequestException)
            {
                var failedAccountDependencyException =
                    new FailedAccountDependencyException(httpRequestException);

                throw CreateAndLogCriticalDependencyException(failedAccountDependencyException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedAccountDependencyException =
                    new FailedAccountDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedAccountDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var failedAccountDependencyException =
                    new FailedAccountDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedAccountDependencyException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundAccountException =
                    new NotFoundAccountException(httpResponseNotFoundException);

                throw CreateAndLogDependencyValidationException(notFoundAccountException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidAccountException =
                    new InvalidAccountException(
                        httpResponseBadRequestException,
                        httpResponseBadRequestException.Data);

                throw CreateAndLogDependencyValidationException(invalidAccountException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                var invalidAccountException =
                    new InvalidAccountException(
                        httpResponseConflictException,
                        httpResponseConflictException.Data);

                throw CreateAndLogDependencyValidationException(invalidAccountException);
            }
            catch (HttpResponseLockedException httpLockedException)
            {
                var lockedAccountException =
                    new LockedAccountException(httpLockedException);

                throw CreateAndLogDependencyValidationException(lockedAccountException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedAccountDependencyException =
                    new FailedAccountDependencyException(httpResponseException);

                throw CreateAndLogDependencyException(failedAccountDependencyException);
            }
            catch (Exception exception)
            {
                var failedAccountServiceException =
                    new FailedAccountServiceException(exception);

                throw CreateAndLogServiceException(failedAccountServiceException);
            }
        }
        private async ValueTask<bool> TryCatch(
        ReturningBooleanFunction returningBooleanFunction)
        {
            try
            {
                return await returningBooleanFunction();
            }
            catch (AccountDependencyException accountDependencyException)
            {
                throw CreateAndLogDependencyException(accountDependencyException);
            }
            catch (AccountServiceException accountServiceException)
            {
                throw CreateAndLogDependencyException(accountServiceException);
            }
            catch (Exception exception)
            {
                var failedAccountProcessingServiceException =
                    new FailedAccountServiceException(exception);

                throw CreateAndLogServiceException(failedAccountProcessingServiceException);
            }
        }

        private AccountValidationException CreateAndLogValidationException(
            Xeption exception)
        {
            var commentValidationException =
                new AccountValidationException(exception);

            this.loggingBroker.LogError(commentValidationException);

            return commentValidationException;
        }

        private AccountDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var commentDependencyException =
                new AccountDependencyException(exception);

            this.loggingBroker.LogCritical(commentDependencyException);

            return commentDependencyException;
        }

        private AccountDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var commentDependencyValidationException =
                new AccountDependencyValidationException(exception);

            this.loggingBroker.LogError(commentDependencyValidationException);

            return commentDependencyValidationException;
        }

        private AccountDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var commentDependencyException =
                new AccountDependencyException(exception);

            this.loggingBroker.LogError(commentDependencyException);

            return commentDependencyException;
        }

        private AccountServiceException CreateAndLogServiceException(Xeption exception)
        {
            var commentServiceException =
                new AccountServiceException(exception);

            this.loggingBroker.LogError(commentServiceException);

            return commentServiceException;
        }
    }
}
