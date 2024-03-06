// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Rides;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Rides
{
    public interface IRideService
    {
        ValueTask<Ride> AddRideAsync(Ride ride);
        ValueTask<List<Ride>> RetrieveAllRidesAsync();
        ValueTask<Ride> RetrieveRideByIdAsync(Guid rideId);
        ValueTask<Ride> ModifyRideAsync(Ride ride);
        ValueTask<Ride> RemoveRideByIdAsync(Guid rideId);
    }
}
