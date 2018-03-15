using Airlines.Business.Manager;
using Airlines.Business.Models;
using Airlines.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Service.Adaptor
{
    public class ScheduleAdaptor
    {
        public ScheduleDto GetScheduleDto(Schedule schedule)
        {
            ScheduleDto sDto = new ScheduleDto();
            sDto.Id = schedule.ID;
            sDto.Date = schedule.Date.ToShortDateString();
            sDto.Time = schedule.Time.ToString();
            sDto.From = schedule.Route.Airport.IATACode;
            sDto.To = schedule.Route.Airport1.IATACode;
            sDto.FlightNumber = schedule.FlightNumber;
            sDto.TotalSeats = schedule.Aircraft.TotalSeats;
            sDto.EconomyPrice = schedule.EconomyPrice;
            sDto.BusinessPrice = Math.Ceiling(schedule.EconomyPrice * (decimal)1.35);
            sDto.FirstClassPrice = Math.Ceiling(schedule.EconomyPrice * (decimal)1.755);
            sDto.Confirmed = schedule.Confirmed;
            sDto.AircraftID = schedule.AircraftID;
            sDto.AircraftName = schedule.Aircraft.Name;

            return sDto;
        }

        public List<ScheduleDto> GetListScheduleDto(List<Schedule> schedules)
        {
            List<ScheduleDto> scheduleDtos = new List<ScheduleDto>();
            foreach(Schedule s in schedules)
            {
                scheduleDtos.Add(GetScheduleDto(s));
            }
            return scheduleDtos;
        }

        public Schedule ToScheduleEntity(ScheduleDto scheduleDto)
        {
            try
            {
                Session2Entities session = new Session2Entities();
                Schedule s = new Schedule();
                s.ID = scheduleDto.Id;  
                s.Date = DateTime.Parse(scheduleDto.Date);
                s.Time = TimeSpan.Parse(scheduleDto.Time);
                s.AircraftID = scheduleDto.AircraftID;
                s.RouteID = session.Routes.Single(r =>
                    r.Airport.IATACode.Equals(scheduleDto.From) &&
                    r.Airport1.IATACode.Equals(scheduleDto.To)).ID;
                s.EconomyPrice = scheduleDto.EconomyPrice;
                s.FlightNumber = scheduleDto.FlightNumber;
                s.Confirmed = scheduleDto.Confirmed;
                return s;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
