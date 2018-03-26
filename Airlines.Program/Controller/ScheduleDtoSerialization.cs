using Airlines.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Program.Controller
{
    class ScheduleDtoSerialization
    {
        public static object Serialize(ScheduleDto schedule)
        {
            object obj = new
            {
                id = schedule.Id,
                date = schedule.Date,
                time = schedule.Time,
                from = schedule.From,
                to = schedule.To,
                flightnumber = schedule.FlightNumber,
                totalseats = schedule.TotalSeats,
                economyprice = schedule.EconomyPrice,
                businessprice = schedule.BusinessPrice,
                firstclassprice = schedule.FirstClassPrice,
                confirmed = schedule.Confirmed,
                aircraftid = schedule.AircraftID,
                aircraftname = schedule.AircraftName
            };
            return obj;
        }
    }
}
