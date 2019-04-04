using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceRoomBookingManager.Models
{
    public class BuildingConfiguration
    {
        public int BuildingId { get; set; }

        public int MinimumNumberOfFloors { get; set; }

        public int MaximumNumberOfFloors { get; set; }

        public int MinimumNumberOfRoomsPerFloor { get; set; }

        public int MaximumNumberOfRoomsPerFloor { get; set; }

        public int MinimumNumberOfBookingsPerRoom { get; set; }

        public int MaximumNumberOfBookingsPerRoom { get; set; }


        public override int GetHashCode()
        {
            var hashString = $"{(BuildingId ^ MinimumNumberOfFloors)}" +
                $"{(MinimumNumberOfFloors ^ MaximumNumberOfFloors)}" +
                $"{(MaximumNumberOfFloors ^ MinimumNumberOfRoomsPerFloor)}" +
                $"{(MinimumNumberOfRoomsPerFloor ^ MaximumNumberOfRoomsPerFloor)}" +
                $"{(MaximumNumberOfRoomsPerFloor ^ MinimumNumberOfBookingsPerRoom)}" +
                $"{(MinimumNumberOfBookingsPerRoom ^ MaximumNumberOfBookingsPerRoom)}" +
                $"{(MaximumNumberOfBookingsPerRoom ^ BuildingId)}";

            return hashString.GetHashCode();
        }
    }
}
