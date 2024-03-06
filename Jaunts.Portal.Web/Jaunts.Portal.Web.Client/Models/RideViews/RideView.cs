// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Rides;
using System;

namespace Jaunts.Portal.Web.Client.Models.RideViews
{
    public class RideView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }
        public Guid FleetId { get; set; }
        public Guid ProviderId { get; set; }
        public RideViewStatus RideStatus { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
