using System.Text.Json.Serialization;

namespace Jaunts.Portal.Web.Client.Models.Rides
{
    public class Ride
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }
        public Guid FleetId { get; set; }
        public Guid ProviderId { get; set; }
        public RideStatus RideStatus { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }

    }
}
