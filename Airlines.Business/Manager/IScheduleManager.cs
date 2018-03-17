using Airlines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Business.Manager
{
    interface IScheduleManager
    {
        Schedule GetSchedule(int id);
        bool AddSchedule(Schedule schedule);
        bool EditSchedule(Schedule schedule);
        bool CancelFlight(int id);
        int FindFlight(string date, string flightnumber);
        List<string> GetAirportList();
        List<Schedule> GetListScheduleFilter(string from,string to,string date,
            string flightnumber,string sortBy,bool descending);
        List<Schedule> GetListScheduleFilter(int start, int end);
        List<int> CsvResult(List<Schedule> schedules);
    }
}
