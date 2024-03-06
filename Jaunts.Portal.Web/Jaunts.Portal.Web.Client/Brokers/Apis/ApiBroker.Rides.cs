// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Rides;

namespace Jaunts.Portal.Web.Client.Brokers.Apis
{
    public partial class ApiBroker
    {
        private const string RidesRelativeUrl = "api/rides";

        public async ValueTask<Ride> PostRideAsync(Ride comment) =>
            await this.PostAsync(RidesRelativeUrl, comment);

        public async ValueTask<List<Ride>> GetAllRidesAsync() =>
            await this.GetAsync<List<Ride>>(RidesRelativeUrl);

        public async ValueTask<Ride> GetRideByIdAsync(Guid commentId) =>
            await this.GetAsync<Ride>($"{RidesRelativeUrl}/{commentId}");

        public async ValueTask<Ride> PutRideAsync(Ride comment) =>
            await this.PutAsync(RidesRelativeUrl, comment);

        public async ValueTask<Ride> DeleteRideByIdAsync(Guid commentId) =>
            await this.DeleteAsync<Ride>($"{RidesRelativeUrl}/{commentId}");
    }
}
