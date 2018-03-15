using Airlines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Business.Repositories
{
    public interface IScheduleRepository
    {
        Schedule GetSchedule(int id);
        bool AddSchedule(Schedule schedule);
        bool EditSchedule(Schedule schedule);
        bool CancelFlight(int id);
    }
}
