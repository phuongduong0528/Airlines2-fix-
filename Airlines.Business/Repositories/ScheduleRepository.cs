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
        private Session2Entities session;

        public ScheduleRepository()
        {
            session = new Session2Entities();
        }

        public bool AddSchedule(Schedule schedule)
        {
            try
            {
                if (schedule == null)
                    return false;
                schedule.ID = session.Schedules.Count() + 1;
                session.Schedules.Add(schedule);
                session.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CancelFlight(int id)
        {
            Schedule sch = session.Schedules.SingleOrDefault(s => s.ID == id);
            if (sch != null)
            {
                if (sch.Confirmed)
                    sch.Confirmed = false;
                else
                    sch.Confirmed = true;
                session.Entry(sch).State = System.Data.Entity.EntityState.Modified;
                session.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditSchedule(Schedule schedule)
        {
            try
            {
                if (schedule == null)
                    return false;
                session.Entry(schedule).State = System.Data.Entity.EntityState.Modified;
                session.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Schedule GetSchedule(int id)
        {
            return session.Schedules.SingleOrDefault(sch => sch.ID == id);
        }
    }
}
