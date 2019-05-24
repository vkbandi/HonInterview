using System;

namespace ConferenceRoomBookingManager.DataSource
{
    public class RoomBooking
    {
        public int Id { get; set; }

        public Room BookedRoom { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string UserId { get; set; }
    }
}
