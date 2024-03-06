// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Identity;
using Jaunts.Portal.Web.Client.Models.Identity.Exceptions;
using Jaunts.Portal.Web.Client.Models.IdentityViews.Exceptions;

namespace Jaunts.Portal.Web.Client.Services.Views.IdentityViews
{
    public partial class IdentityViewService
    {
        private delegate ValueTask<UserAccountDetailsResponse> ReturningUserAccountDetailsViewFunction();
        private delegate ValueTask<bool> ReturningBooleanViewFunction();
        private delegate void ReturningNothingFunction();

        private async ValueTask<UserAccountDetailsResponse> TryCatch(ReturningUserAccountDetailsViewFunction returningUserAccountDetailsViewFunction)
        {
            try
            {
                return await returningUserAccountDetailsViewFunction();
            }
            catch (NullIdentityViewException nullAccountViewException)
            {
                throw CreateAndLogValidationException(nullAccountViewException);
            }
            catch (InvalidIdentityViewException invalidAccountViewException)
            {
                throw CreateAndLogValidationException(invalidAccountViewException);
            }
            catch (AccountValidationException AccountValidationException)
            {
                throw CreateAndLogDependencyValidationException(AccountValidationException);
            }
            catch (AccountDependencyValidationException AccountDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(AccountDependencyValidationException);
            }
            catch (AccountDependencyException AccountDependencyException)
            {
                throw CreateAndLogDependencyException(AccountDependencyException);
            }
            catch (AccountServiceException AccountServiceException)
            {
                throw CreateAndLogDependencyException(AccountServiceException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogServiceException(serviceException);
            }
        }

        private async ValueTask<bool> TryCatch(ReturningBooleanViewFunction returningBooleanViewFunction)
        {
            try
            {
                return await returningBooleanViewFunction();
            }
            catch (AccountDependencyException accountDependencyException)
            {
                throw CreateAndLogDependencyException(accountDependencyException);
            }
            catch (AccountServiceException accountServiceException)
            {
                throw CreateAndLogDependencyException(accountServiceException);
            }
            catch (InvalidIdentityViewException invalidAccountViewException)
            {
                throw CreateAndLogValidationException(invalidAccountViewException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogServiceException(serviceException);
            }
        }
        private void TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                returningNothingFunction();
            }
            catch (InvalidIdentityViewException invalidAccountViewException)
            {
                throw CreateAndLogValidationException(invalidAccountViewException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogServiceException(serviceException);
            }
        }

        private IdentityViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var AccountViewValidationException = new IdentityViewValidationException(exception);
            this.loggingBroker.LogError(AccountViewValidationException);

            return AccountViewValidationException;
        }

        private IdentityViewDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var AccountViewDependencyValidationException =
                new IdentityViewDependencyValidationException(exception.InnerException);

            this.loggingBroker.LogError(AccountViewDependencyValidationException);

            return AccountViewDependencyValidationException;
        }

        private IdentityViewDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var AccountViewDependencyException = new IdentityViewDependencyException(exception);
            this.loggingBroker.LogError(AccountViewDependencyException);

            return AccountViewDependencyException;
        }

        private IdentityViewServiceException CreateAndLogServiceException(Exception exception)
        {
            var AccountViewServiceException = new IdentityViewServiceException(exception);
            this.loggingBroker.LogError(AccountViewServiceException);

            return AccountViewServiceException;
        }
    }
}
