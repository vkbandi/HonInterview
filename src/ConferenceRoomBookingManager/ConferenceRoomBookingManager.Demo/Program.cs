using ConferenceRoomBookingManager.DataSource;
using ConferenceRoomBookingManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceRoomBookingManager.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            var rdc = new RoomBookingDataClient(configuration);
            var roomsList = rdc.GetAllRooms();

            foreach (var room in roomsList)
            {
                foreach (var booking in room.Bookings)
                {
                    Console.WriteLine($"{room.Name}\t{booking.StartTime}\t{booking.EndTime}");
                }

                Console.WriteLine();
            }

            DateTime preferredStartTime, preferredEndTime;
            while(true)
            {
                try
                {
                    Console.Write("Enter preferred start time : ");
                    preferredStartTime = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter preferred end time : ");
                    preferredEndTime = DateTime.Parse(Console.ReadLine());

                    if (preferredStartTime >= preferredEndTime)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Error : Start time should be less than end time, please try again");
                        Console.WriteLine();

                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Error : Invalid Time, please try again");
                    Console.WriteLine();

                    Console.ResetColor();
                }
            }

            RoomFinder roomFinder = new RoomFinder();
            var availableSlotCollections = roomFinder.GetAvailableBookingSlots(roomsList, preferredStartTime, preferredEndTime);

            foreach (var availableSolotCollection in availableSlotCollections)
            {
                Console.WriteLine(availableSolotCollection);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static BuildingConfiguration GetConfiguration()
        {
            return new BuildingConfiguration
            {
                BuildingId = Convert.ToInt32(ConfigurationManager.AppSettings["BuildingId"]),
                MaximumNumberOfFloors = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumNumberOfFloors"]),
                MinimumNumberOfFloors = Convert.ToInt32(ConfigurationManager.AppSettings["MinimumNumberOfFloors"]),
                MaximumNumberOfRoomsPerFloor = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumNumberOfRoomsPerFloor"]),
                MinimumNumberOfRoomsPerFloor = Convert.ToInt32(ConfigurationManager.AppSettings["MinimumNumberOfRoomsPerFloor"]),
                MaximumNumberOfBookingsPerRoom = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumNumberOfBookingsPerRoom"]),
                MinimumNumberOfBookingsPerRoom = Convert.ToInt32(ConfigurationManager.AppSettings["MinimumNumberOfBookingsPerRoom"])
            };
        }
    }
}
