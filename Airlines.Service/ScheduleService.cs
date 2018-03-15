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
            return ScheduleManager.AddSchedule(scheduleAdaptor.ToScheduleEntity(scheduleDto));
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
            return ScheduleManager.EditSchedule(scheduleAdaptor.ToScheduleEntity(scheduleDto));
        }

        public int FindFlight(string date, string flightnumber)
        {
            return ScheduleManager.FindFlight(date, flightnumber);
        }

        public List<int> ImportService(List<ScheduleDto> scheduleDtos)
        {
            int successful = 0;
            int fail = 0;

            foreach (ScheduleDto sdto in scheduleDtos)
            {
                if (sdto.Id == 0) // 0 = ADD; ID WILL AUTOMATICALLY ASSIGN WHEN ADDED TO DATABASE
                {
                    int i = FindFlight(sdto.Date, sdto.FlightNumber); //FIND DUPLICATE
                    if (i == 0) //IF NO DUPLICATE
                    {
                        bool check = AddSchedule(sdto);
                        if (check)
                            successful++;
                        else
                            fail++;
                    }
                    else
                        fail++;
                }
                else //EDIT
                {
                    int i = FindFlight(sdto.Date, sdto.FlightNumber);//FIND SCHEDULE NEED TO EDIT
                    if (i > 0)
                    {
                        sdto.Id = i; //ASSIGN ID
                        bool check = EditSchedule(sdto);
                        if (check)
                            successful++;
                        else
                            fail++;
                    }
                    else
                        fail++;
                }
            }
            List<int> result = new List<int>();
            result.Add(successful);
            result.Add(fail);
            return result;
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
                return scheduleAdaptor.GetScheduleDto(ScheduleManager.GetSchedule(_id));
            else
                return null;
        }
    }
}
