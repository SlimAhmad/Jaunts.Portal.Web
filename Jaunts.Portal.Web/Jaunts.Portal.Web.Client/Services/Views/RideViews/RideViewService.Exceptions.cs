// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Identity.Exceptions;
using Jaunts.Portal.Web.Client.Models.RideViews;
using Jaunts.Portal.Web.Client.Models.RideViews.Exceptions;

namespace Jaunts.Portal.Web.Client.Services.Views.RideViews
{
    public partial class RideViewService
    {
        private delegate ValueTask<RideView> ReturningRideViewFunction();
        private delegate ValueTask<List<RideView>> ReturningRideViewsFunction();
        private delegate void ReturningNothingFunction();

        private async ValueTask<RideView> TryCatch(ReturningRideViewFunction returningRideViewFunction)
        {
            try
            {
                return await returningRideViewFunction();
            }
            catch (NullRideViewException nullRideViewException)
            {
                throw CreateAndLogValidationException(nullRideViewException);
            }
            catch (InvalidRideViewException invalidRideViewException)
            {
                throw CreateAndLogValidationException(invalidRideViewException);
            }
            catch (AccountValidationException RideValidationException)
            {
                throw CreateAndLogDependencyValidationException(RideValidationException);
            }
            catch (AccountDependencyValidationException RideDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(RideDependencyValidationException);
            }
            catch (AccountDependencyException RideDependencyException)
            {
                throw CreateAndLogDependencyException(RideDependencyException);
            }
            catch (AccountServiceException RideServiceException)
            {
                throw CreateAndLogDependencyException(RideServiceException);
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
            catch (InvalidRideViewException invalidRideViewException)
            {
                throw CreateAndLogValidationException(invalidRideViewException);
            }
            catch (Exception serviceException)
            {
                throw CreateAndLogServiceException(serviceException);
            }
        }

        private async ValueTask<List<RideView>> TryCatch(ReturningRideViewsFunction returningRideViewsFunction)
        {
            try
            {
                return await returningRideViewsFunction();
            }
            catch (AccountDependencyException RideDependencyException)
            {
                throw CreateAndLogDependencyException(RideDependencyException);
            }
            catch (AccountServiceException RideServiceException)
            {
                throw CreateAndLogDependencyException(RideServiceException);
            }
            catch (Exception serviceException)
            {
                var failedRideViewServiceException = new FailedRideViewServiceException(serviceException);

                throw CreateAndLogServiceException(failedRideViewServiceException);
            }
        }

        private RideViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var RideViewValidationException = new RideViewValidationException(exception);
            this.loggingBroker.LogError(RideViewValidationException);

            return RideViewValidationException;
        }

        private RideViewDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var RideViewDependencyValidationException =
                new RideViewDependencyValidationException(exception.InnerException);

            this.loggingBroker.LogError(RideViewDependencyValidationException);

            return RideViewDependencyValidationException;
        }

        private RideViewDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var RideViewDependencyException = new RideViewDependencyException(exception);
            this.loggingBroker.LogError(RideViewDependencyException);

            return RideViewDependencyException;
        }

        private RideViewServiceException CreateAndLogServiceException(Exception exception)
        {
            var RideViewServiceException = new RideViewServiceException(exception);
            this.loggingBroker.LogError(RideViewServiceException);

            return RideViewServiceException;
        }
    }
}
