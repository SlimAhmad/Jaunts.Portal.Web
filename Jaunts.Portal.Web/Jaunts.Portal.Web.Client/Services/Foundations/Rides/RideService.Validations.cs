// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Rides;
using Jaunts.Portal.Web.Client.Models.Rides.Exceptions;

namespace Jaunts.Portal.Web.Client.Services.Foundations.Rides
{
    public partial class RideService
    {
        private void ValidateRideOnAdd(Ride ride)
        {
            ValidateRideIsNotNull(ride);

            Validate(
                (Rule: IsInvalid(ride.Id), Parameter: nameof(Ride.Id)),
                (Rule: IsInvalid(ride.Location), Parameter: nameof(Ride.Location)),
                (Rule: IsInvalid(ride.CreatedDate), Parameter: nameof(Ride.CreatedDate)),
                (Rule: IsInvalid(ride.UpdatedDate), Parameter: nameof(Ride.UpdatedDate)),
                (Rule: IsInvalid(ride.Description), Parameter: nameof(Ride.Description)));
        }

        private void ValidateRideOnUpdate(Ride ride)
        {
            ValidateRideIsNotNull(ride);

            Validate(
                (Rule: IsInvalid(ride.Id), Parameter: nameof(Ride.Id)),
                (Rule: IsInvalid(ride.Location), Parameter: nameof(Ride.Location)),
                (Rule: IsInvalid(ride.CreatedDate), Parameter: nameof(Ride.CreatedDate)),
                (Rule: IsInvalid(ride.UpdatedDate), Parameter: nameof(Ride.UpdatedDate)),
                (Rule: IsInvalid(ride.Description), Parameter: nameof(Ride.Description)));
        }

        private static void ValidateRideIsNotNull(Ride ride)
        {
            if (ride is null)
            {
                throw new NullRideException();
            }
        }

        public static void ValidateRideId(Guid rideId) =>
            Validate((Rule: IsInvalid(rideId), Parameter: nameof(Ride.Id)));

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidRideException = new InvalidRideException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidRideException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidRideException.ThrowIfContainsErrors();
        }
    }
}
