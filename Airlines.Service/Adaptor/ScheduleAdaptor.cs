using Airlines.Business.Manager;
using Airlines.Business.Models;
using Airlines.Service.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            sDto.Date = schedule.Date.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);
            sDto.Time = schedule.Time.ToString(@"hh\:mm", CultureInfo.InvariantCulture);
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
                s.Date = DateTime.ParseExact(scheduleDto.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                s.Time = TimeSpan.ParseExact(scheduleDto.Time,@"hh\:mm", CultureInfo.InvariantCulture);
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

        public List<Schedule> ToListScheduleEntity(List<ScheduleDto> scheduleDtos)
        {
            List<Schedule> result = new List<Schedule>();
            foreach (ScheduleDto sdto in scheduleDtos)
            {
                result.Add(ToScheduleEntity(sdto));
            }
            return result;
        }

    }
}
