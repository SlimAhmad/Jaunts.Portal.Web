// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Brokers.DateTimes;
using Jaunts.Portal.Web.Client.Brokers.Loggings;
using Jaunts.Portal.Web.Client.Brokers.Navigations;
using Jaunts.Portal.Web.Client.Models.Rides;
using Jaunts.Portal.Web.Client.Models.RideViews;
using Jaunts.Portal.Web.Client.Services.Foundations.Rides;
using Jaunts.Portal.Web.Client.Services.Foundations.Users;

namespace Jaunts.Portal.Web.Client.Services.Views.RideViews
{
    public partial class RideViewService : IRideViewService
    {
        private readonly IRideService RideService;
        private readonly IUserService userService;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly INavigationBroker navigationBroker;
        private readonly ILoggingBroker loggingBroker;

        public RideViewService(
            IRideService RideService,
            IUserService userService,
            IDateTimeBroker dateTimeBroker,
            INavigationBroker navigationBroker,
            ILoggingBroker loggingBroker)
        {
            this.RideService = RideService;
            this.userService = userService;
            this.dateTimeBroker = dateTimeBroker;
            this.navigationBroker = navigationBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<RideView> AddRideViewAsync(RideView rideView) =>
        TryCatch(async () =>
        {
            ValidateRideView(rideView);
            Ride ride = MapToRide(rideView);
            await this.RideService.AddRideAsync(ride);

            return rideView;
        });

        public void NavigateTo(string route) =>
        TryCatch(() =>
        {
            ValidateRoute(route);
            this.navigationBroker.NavigateTo(route);
        });

        public ValueTask<List<RideView>> RetrieveAllRideViewsAsync() =>
        TryCatch(async () =>
        {
            List<Ride> Rides =
                await this.RideService.RetrieveAllRidesAsync();

            return Rides.Select(AsRideView).ToList();
        });

        private Ride MapToRide(RideView RideView)
        {
            Guid currentLoggedInUserId = this.userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = this.dateTimeBroker.GetCurrentDateTimeOffset();

            return new Ride
            {
                Id = Guid.NewGuid(),
                RideStatus = (RideStatus)RideView.RideStatus,
                CreatedBy = currentLoggedInUserId,
                UpdatedBy = currentLoggedInUserId,
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime
            };
        }

        private static Func<Ride, RideView> AsRideView =>
            Ride => new RideView
            {
                Id = Ride.Id,
                Description = Ride.Description,
                Location = Ride.Location,
                Name = Ride.Name,
                Price = Ride.Price,
                Discount = Ride.Discount,
                RideStatus = (RideViewStatus)Ride.RideStatus,
            };
    }
}
