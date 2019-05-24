using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceRoomBookingManager.DataSource
{
    public class RoomBookinDataClient
    {
        private static readonly Random _random = new Random();

        public List<RoomBooking> GetAllRoomBookings()
        {
            List<RoomBooking> roomBookingData = new List<RoomBooking>();
            int noOfFloors = _random.Next(5, 11);

            Console.WriteLine("Number of floor : " + noOfFloors);
            for (int f = 1; f <= noOfFloors; f++)
            {
                int roomsInCurrentFloor = _random.Next(5, 11);
                Console.WriteLine($"Rooms on Floor {f} : " + roomsInCurrentFloor);

                for (int r = 1; r <= roomsInCurrentFloor; r++)
                {
                    DateTime bookingStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
                    DateTime maxAllowedBookingEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 30, 0);

                    var maxNoOfBookings = _random.Next(5, 11);
                    Console.WriteLine($"Max number of bookings for Room {r} on Floor {f} : " + maxNoOfBookings);

                    for (int b = 1; b <= maxNoOfBookings; b++)
                    {
                        var bookingGapInMinutes = _random.Next(0, 9) * 15;
                        bookingStartTime = bookingStartTime.AddMinutes(bookingGapInMinutes);

                        var bookingTimeInMinutes = _random.Next(1, 5) * 15;

                        var bookingEndTime = bookingStartTime.AddMinutes(bookingTimeInMinutes);
                        if (bookingEndTime > maxAllowedBookingEndTime)
                        {
                            break;
                        }

                        var booking = new RoomBooking()
                        {
                            BookedRoom = new Room()
                            {
                                Name = "Room " + r,
                                RoomNumber = r,
                                BookingPriority = r,
                                FloorNumber = f
                            },
                            StartTime = bookingStartTime,
                            EndTime = bookingEndTime,
                            Id = (f + r + b),
                            UserId = Guid.NewGuid().ToString()
                        };

                        bookingStartTime = bookingEndTime;

                        roomBookingData.Add(booking);
                    }
                }

                Console.WriteLine();
            }

            return roomBookingData;
        }
    }
}