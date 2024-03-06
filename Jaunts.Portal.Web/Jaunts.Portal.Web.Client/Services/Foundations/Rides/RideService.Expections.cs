// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Rides;
using Jaunts.Portal.Web.Client.Models.Rides.Exceptions;
using RESTFulSense.WebAssembly.Exceptions;
using Xeptions;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Rides
{
    public partial class RideService
    {
        private delegate ValueTask<Ride> ReturningRideFunction();
        private delegate ValueTask<List<Ride>> ReturningRidesFunction();

        private async ValueTask<Ride> TryCatch(ReturningRideFunction returningRideFunction)
        {
            try
            {
                return await returningRideFunction();
            }
            catch (NullRideException nullRideException)
            {
                throw CreateAndLogValidationException(nullRideException);
            }
            catch (InvalidRideException invalidRideException)
            {
                throw CreateAndLogValidationException(invalidRideException);
            }
            catch (HttpRequestException httpRequestException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpRequestException);

                throw CreateAndLogCriticalDependencyException(failedRideDependencyException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedRideDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedRideDependencyException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundRideException =
                    new NotFoundRideException(httpResponseNotFoundException);

                throw CreateAndLogDependencyValidationException(notFoundRideException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidRideException =
                    new InvalidRideException(
                        httpResponseBadRequestException,
                        httpResponseBadRequestException.Data);

                throw CreateAndLogDependencyValidationException(invalidRideException);
            }
            catch (HttpResponseConflictException httpResponseConflictException)
            {
                var invalidRideException =
                    new InvalidRideException(
                        httpResponseConflictException,
                        httpResponseConflictException.Data);

                throw CreateAndLogDependencyValidationException(invalidRideException);
            }
            catch (HttpResponseLockedException httpLockedException)
            {
                var lockedRideException =
                    new LockedRideException(httpLockedException);

                throw CreateAndLogDependencyValidationException(lockedRideException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpResponseException);

                throw CreateAndLogDependencyException(failedRideDependencyException);
            }
            catch (Exception exception)
            {
                var failedRideServiceException =
                    new FailedRideServiceException(exception);

                throw CreateAndLogRideServiceException(failedRideServiceException);
            }
        }

        private async ValueTask<List<Ride>> TryCatch(ReturningRidesFunction returningRidesFunction)
        {
            try
            {
                return await returningRidesFunction();
            }
            catch (HttpRequestException httpRequestException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpRequestException);

                throw CreateAndLogCriticalDependencyException(failedRideDependencyException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedRideDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedRideDependencyException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedRideDependencyException =
                    new FailedRideDependencyException(httpResponseException);

                throw CreateAndLogDependencyException(failedRideDependencyException);
            }
            catch (Exception exception)
            {
                var failedRideServiceException =
                    new FailedRideServiceException(exception);

                throw CreateAndLogRideServiceException(failedRideServiceException);
            }
        }

        private RideValidationException CreateAndLogValidationException(
            Xeption exception)
        {
            var commentValidationException =
                new RideValidationException(exception);

            this.loggingBroker.LogError(commentValidationException);

            return commentValidationException;
        }

        private RideDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var commentDependencyException =
                new RideDependencyException(exception);

            this.loggingBroker.LogCritical(commentDependencyException);

            return commentDependencyException;
        }

        private RideDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var commentDependencyValidationException =
                new RideDependencyValidationException(exception);

            this.loggingBroker.LogError(commentDependencyValidationException);

            return commentDependencyValidationException;
        }

        private RideDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var commentDependencyException =
                new RideDependencyException(exception);

            this.loggingBroker.LogError(commentDependencyException);

            return commentDependencyException;
        }

        private RideServiceException CreateAndLogRideServiceException(Xeption exception)
        {
            var commentServiceException =
                new RideServiceException(exception);

            this.loggingBroker.LogError(commentServiceException);

            return commentServiceException;
        }
    }
}
