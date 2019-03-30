using ConferenceRoomBookingManager.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceRoomBookingManager.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var rdc = new RoomBookinDataClient();
            var bookings = rdc.GetAllRoomBookings();

            foreach(var booking in bookings)
            {
                Console.WriteLine($"{booking.BookedRoom.Name} on Floor {booking.BookedRoom.FloorNumber}\t{booking.StartTime}\t{booking.EndTime}");
            }

            Console.ReadLine();
        }
    }
}
