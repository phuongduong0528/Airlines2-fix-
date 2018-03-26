using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airlines.Business.Models;

namespace Airlines.Business.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private Session2Entities _session2DbContext;

        public ScheduleRepository()
        {
            _session2DbContext = new Session2Entities();
        }

        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                if (schedule == null)
                    return false;
                schedule.ID = _session2DbContext.Schedules.Max(s => s.ID) + 1;
                _session2DbContext.Schedules.Add(schedule);
                _session2DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CancelFlight(int id)
        {
            Schedule sch = _session2DbContext.Schedules.SingleOrDefault(s => s.ID == id);
            if (sch != null)
            {
                if (sch.Confirmed)
                    sch.Confirmed = false;
                else
                    sch.Confirmed = true;
                _session2DbContext.Entry(sch).State = System.Data.Entity.EntityState.Modified;
                _session2DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditSchedule(Schedule sch)
        {
            try
            {
                if (sch == null)
                    return false;
                _session2DbContext.Entry(sch).State = System.Data.Entity.EntityState.Modified;
                _session2DbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Schedule GetSchedule(int id)
        {
            return _session2DbContext.Schedules.SingleOrDefault(sch => sch.ID == id);
        }
    }
}
