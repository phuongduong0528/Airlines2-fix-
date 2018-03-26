using Airlines.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Business.Repositories
{
    public class AirportRepository
    {
        private Session2Entities _session2DbContext;

        public AirportRepository()
        {
            _session2DbContext = new Session2Entities();
        }

        public List<string> GetAirportList()
        {
            List<string> result = new List<string>();
            foreach(Airport a in _session2DbContext.Airports)
            {
                result.Add(a.IATACode);
            }
            return result;
        }
    }
}
