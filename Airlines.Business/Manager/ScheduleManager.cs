using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airlines.Business.Models;
using Airlines.Business.Repositories;

namespace Airlines.Business.Manager
{
    public class ScheduleManager : IScheduleManager
    {
        ScheduleRepository scheduleRepository;
        AirportRepository airportRepository;
        Session2Entities session;

        public ScheduleManager()
        {
            scheduleRepository = new ScheduleRepository();
            airportRepository = new AirportRepository();
            session = new Session2Entities();
        }

        public bool AddSchedule(Schedule schedule)
        {
            return scheduleRepository.AddSchedule(schedule);
        }

        public bool CancelFlight(int id)
        {
            return scheduleRepository.CancelFlight(id);
        }

        public bool EditSchedule(Schedule schedule)
        {
            return scheduleRepository.EditSchedule(schedule);
        }

        public int FindFlight(string date, string flightnumber)
        {
            DateTime d;
            try
            {
                d = DateTime.Parse(date);
                Schedule s = session.Schedules.Single(sch => sch.Date.Equals(d) && sch.FlightNumber.Equals(flightnumber));
                return s.ID;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public List<string> GetAirportList()
        {
            return airportRepository.GetAirportList();
        }

        public List<Schedule> GetListScheduleFilter(string from, string to, string date, 
            string flightnumber, string sortBy, bool descending)
        {
            List<Schedule> result = new List<Schedule>();

            result = session.Schedules.Where(sch => 
                sch.Route.Airport.IATACode.Equals(from) && 
                sch.Route.Airport1.IATACode.Equals(to)).ToList();

            DateTime d;
            if (DateTime.TryParse(date, out d))
                result = result.Where(r => r.Date.Equals(d)).ToList();

            if (!String.IsNullOrWhiteSpace(flightnumber))
                result = result.Where(r => r.FlightNumber.Equals(flightnumber)).ToList();

            switch (sortBy)
            {
                case "Date":
                    if (!descending)
                        result = result.OrderBy(r => r.Date).ToList();
                    else
                        result = result.OrderByDescending(r => r.Date).ToList();
                    break;
                case "Time":
                    if (!descending)
                        result = result.OrderBy(r => r.Time).ToList();
                    else
                        result = result.OrderByDescending(r => r.Time).ToList();
                    break;
                case "Price":
                    if (!descending)
                        result = result.OrderBy(r => r.EconomyPrice).ToList();
                    else
                        result = result.OrderByDescending(r => r.EconomyPrice).ToList();
                    break;
                default:
                    if (!descending)
                        result = result.OrderBy(r => r.Date).ThenBy(r=>r.Time).ToList();
                    else
                        result = result.OrderByDescending(r => r.Date).ThenByDescending(r=>r.Time).ToList();
                    break;
            }
            return result;
        }

        public List<Schedule> GetListScheduleFilter(int start, int end)
        {
            if (start >= 0 && end >= 0)
                return session.Schedules.Skip(start - 1).Take(end - start + 1).ToList();
            else
                return null;
        }

        public Schedule GetSchedule(int id)
        {
            return scheduleRepository.GetSchedule(id);
        }
    }
}
