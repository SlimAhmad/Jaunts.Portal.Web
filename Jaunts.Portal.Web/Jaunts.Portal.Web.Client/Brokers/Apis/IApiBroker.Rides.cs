// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jaunts.Portal.Web.Client.Models.Rides;

namespace Jaunts.Portal.Web.Client.Brokers.Apis
{
    public partial interface IApiBroker
    {
        ValueTask<Ride> PostRideAsync(Ride ride);
        ValueTask<List<Ride>> GetAllRidesAsync();
        ValueTask<Ride> GetRideByIdAsync(Guid rideId);
        ValueTask<Ride> PutRideAsync(Ride ride);
        ValueTask<Ride> DeleteRideByIdAsync(Guid rideId);
    }
}
