using ConferenceRoomBookingManager.DataSource;
using ConferenceRoomBookingManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConferenceRoomBookingManager.API.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult Index()
        {
            var buildingConfiguration = GetConfiguration();
            var rc = new RoomBookingDataClient(buildingConfiguration);
            var bookingData = rc.GetAllRooms();

            return Json(bookingData, JsonRequestBehavior.AllowGet);
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