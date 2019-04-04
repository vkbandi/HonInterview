using System;

namespace ConferenceRoomBookingManager.Models
{
    public class AvailableSlot
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string RoomName { get; set; }

        public override string ToString()
        {
            return $"{RoomName}\t{StartTime}\t{EndTime}";
        }
    }
}
