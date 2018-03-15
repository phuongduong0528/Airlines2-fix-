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
        Session2Entities session;

        public AirportRepository()
        {
            session = new Session2Entities();
        }

        public List<string> GetAirportList()
        {
            List<string> result = new List<string>();
            foreach(Airport a in session.Airports)
            {
                result.Add(a.IATACode);
            }
            return result;
        }
    }
}
