using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using ConferenceRoomBookingManager.Models;

namespace ConferenceRoomBookingManager.DataSource
{
    public class RoomBookingDataClient
    {
        private static readonly Random _random = new Random();
        private readonly BuildingConfiguration _configuration;

        public RoomBookingDataClient(BuildingConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Room> GetAllRooms()
        {
            string buildingRoomsDataFileName = $"RoomsInBuilding{_configuration.BuildingId}{_configuration.GetHashCode()}.json";
            if (File.Exists(buildingRoomsDataFileName))
            {
                try
                {
                    string buildingRoomsJsonData = File.ReadAllText(buildingRoomsDataFileName);
                    return JsonConvert.DeserializeObject<List<Room>>(buildingRoomsJsonData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine();
                }
            }

            List<Room> roomsInBuildingData = new List<Room>();
            int noOfFloors = _random.Next(_configuration.MinimumNumberOfFloors, _configuration.MaximumNumberOfFloors + 1);

            for (int f = 1; f <= noOfFloors; f++)
            {
                int roomsInCurrentFloor = _random.Next(_configuration.MinimumNumberOfRoomsPerFloor, _configuration.MaximumNumberOfRoomsPerFloor + 1);

                for (int r = 1; r <= roomsInCurrentFloor; r++)
                {
                    DateTime nextBookingStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
                    DateTime maxAllowedBookingEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 30, 0);

                    var maxNoOfBookings = _random.Next(_configuration.MinimumNumberOfBookingsPerRoom, _configuration.MinimumNumberOfBookingsPerRoom + 1);

                    int roomNumber = (f * 100) + r;
                    var currrentRoom = new Room()
                    {
                        Name = "R" + roomNumber,
                        RoomNumber = roomNumber,
                        BookingPriority = r,
                        FloorNumber = f,
                        Bookings = new List<Booking>()
                    };

                    for (int b = 1; b <= maxNoOfBookings; b++)
                    {
                        var bookingGapInMinutes = _random.Next(0, 9) * 15;
                        nextBookingStartTime = nextBookingStartTime.AddMinutes(bookingGapInMinutes);

                        var bookingTimeInMinutes = _random.Next(1, 5) * 15;

                        var bookingEndTime = nextBookingStartTime.AddMinutes(bookingTimeInMinutes);
                        if (bookingEndTime > maxAllowedBookingEndTime)
                        {
                            break;
                        }

                        currrentRoom.Bookings.Add(new Booking
                        {
                            Id = (roomNumber * 100) + b,
                            StartTime = nextBookingStartTime,
                            EndTime = bookingEndTime,
                            UserId = Guid.NewGuid().ToString()
                        });

                        nextBookingStartTime = bookingEndTime;
                    }

                    roomsInBuildingData.Add(currrentRoom);
                }
            }


            try
            {
                string bookingDataAsJson = JsonConvert.SerializeObject(roomsInBuildingData);
                File.WriteAllText(buildingRoomsDataFileName, bookingDataAsJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine();
            }

            return roomsInBuildingData;
        }
    }
}