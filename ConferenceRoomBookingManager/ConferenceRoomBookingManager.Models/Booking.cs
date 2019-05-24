using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceRoomBookingManager.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string UserId { get; set; }
    }
}
