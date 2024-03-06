// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.RideViews;
using Jaunts.Portal.Web.Client.Models.RideViews.Exceptions;

namespace Jaunts.Portal.Web.Client.Services.Views.RideViews
{
    public partial class RideViewService
    {
        private static void ValidateRideView(RideView rideView)
        {
            if (rideView is null)
            {
                throw new NullRideViewException();
            }
        }

        private static void ValidateRoute(string route)
        {
            if (IsInvalid(route))
            {
                throw new InvalidRideViewException(
                    parameterName: "Route",
                    parameterValue: route);
            }
        }

        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);
    }
}
