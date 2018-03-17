using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Airlines.Business.Manager;
using Airlines.Service.Adaptor;
using Airlines.Service.Dto;

namespace Airlines.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ScheduleService" in both code and config file together.
    public class ScheduleService : IScheduleService
    {
        private ScheduleAdaptor scheduleAdaptor = new ScheduleAdaptor();

        private ScheduleManager _scheduleManager;
        public ScheduleManager ScheduleManager => _scheduleManager ?? (_scheduleManager = new ScheduleManager());

        public bool AddSchedule(ScheduleDto scheduleDto)
        {
            return ScheduleManager.AddSchedule(
                scheduleAdaptor.ToScheduleEntity(scheduleDto)
                );
        }

        public List<string> AirportList()
        {
            return ScheduleManager.GetAirportList();
        }

        public bool CancelFlight(int id)
        {
            return ScheduleManager.CancelFlight(id);
        }

        public bool EditSchedule(ScheduleDto scheduleDto)
        {
            return ScheduleManager.EditSchedule(
                scheduleAdaptor.ToScheduleEntity(scheduleDto)
                );
        }

        public int FindFlight(string date, string flightnumber)
        {
            return ScheduleManager.FindFlight(date, flightnumber);
        }

        public List<int> CsvResult(List<ScheduleDto> scheduleDtos)
        {
            return ScheduleManager.CsvResult(
                scheduleAdaptor.ToListScheduleEntity(scheduleDtos)
                );
        }

        public List<ScheduleDto> ListScheduleFilter(string from, string to, string date, 
            string flightnumber, string sortBy, bool descending)
        {
            return scheduleAdaptor.GetListScheduleDto(
                ScheduleManager.GetListScheduleFilter(from, to, date,
                flightnumber, sortBy, descending)
                );
        }

        public ScheduleDto ScheduleById(string id)
        {
            int _id;
            if (Int32.TryParse(id, out _id))
                return scheduleAdaptor.GetScheduleDto(
                    ScheduleManager.GetSchedule(_id)
                    );
            else
                return null;
        }
    }
}
