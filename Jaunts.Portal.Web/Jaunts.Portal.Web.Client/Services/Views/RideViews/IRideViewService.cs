// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.RideViews;

namespace Jaunts.Portal.Web.Client.Services.Views.RideViews
{
    public interface IRideViewService
    {
        ValueTask<RideView> AddRideViewAsync(RideView rideView);
        ValueTask<List<RideView>> RetrieveAllRideViewsAsync();

        void NavigateTo(string route);
    }
}
