// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Brokers.Apis;
using Jaunts.Portal.Web.Client.Brokers.Loggings;
using Jaunts.Portal.Web.Client.Models.Rides;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Rides
{
    public partial class RideService : IRideService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public RideService(
            IApiBroker apiBroker,
            ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Ride> AddRideAsync(Ride ride) =>
        TryCatch(async () =>
        {
            ValidateRideOnAdd(ride);

            return await this.apiBroker.PostRideAsync(ride);
        });

        public ValueTask<List<Ride>> RetrieveAllRidesAsync() =>
        TryCatch(async () => await this.apiBroker.GetAllRidesAsync());

        public ValueTask<Ride> RetrieveRideByIdAsync(Guid rideId) =>
        TryCatch(async () =>
        {
            ValidateRideId(rideId);

            return await this.apiBroker.GetRideByIdAsync(rideId);
        });

        public ValueTask<Ride> ModifyRideAsync(Ride ride) =>
        TryCatch(async () =>
        {
            ValidateRideOnUpdate(ride);

            return await this.apiBroker.PutRideAsync(ride);
        });

        public ValueTask<Ride> RemoveRideByIdAsync(Guid rideId) =>
        TryCatch(async () =>
        {
            ValidateRideId(rideId);

            return await this.apiBroker.DeleteRideByIdAsync(rideId);
        });
    }
}
