using ConferenceRoomBookingManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceRoomBookingManager.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }

        public string Name { get; set; }

        public int FloorNumber { get; set; }

        /// <summary>
        /// Rooms with higher priority should be preferred
        /// </summary>
        public int BookingPriority { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
