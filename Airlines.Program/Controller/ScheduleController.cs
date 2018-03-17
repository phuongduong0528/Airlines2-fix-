using Airlines.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Airlines.Program.Controller
{
    public class ScheduleController
    {
        private const string baseUrl = "http://localhost:8733/ScheduleService";

        public async Task<List<string>> GetOffice()
        {
            ScheduleRequest<List<string>> request = new ScheduleRequest<List<string>>();
            request.Url = baseUrl + "/Schedule/Airport";
            List<string> re = await request.GetData();
            return re;
        }

        public async Task<List<ScheduleDto>> LoadListSchedule(string _from, string _to, string _date,
            string _flightnumber, string _sortBy, bool _descending)
        {
            ScheduleRequest<List<ScheduleDto>> request = new ScheduleRequest<List<ScheduleDto>>();
            request.Url = baseUrl + "/Schedule/List";
            object body = new
            {
                from = _from,
                to = _to,
                date = _date,
                flightnumber = _flightnumber,
                sortBy = _sortBy,
                descending = _descending
            };
            List<ScheduleDto> re = await request.SubmitData(Method.POST, body);
            return re;
        }

        public async Task<ScheduleDto> LoadSchedule(int id)
        {
            ScheduleRequest<ScheduleDto> request = new ScheduleRequest<ScheduleDto>();
            request.Url = baseUrl + "/Schedule/"+id;
            ScheduleDto re = await request.GetData();
            return re;
        }

        public async Task CancelFlight(int id)
        {
            ScheduleRequest<bool> request = new ScheduleRequest<bool>();
            request.Url = baseUrl + "/Schedule/Flight";
            await request.SubmitData(Method.PUT,id);
        }

        public async Task<bool> AddSchedule(ScheduleDto s)
        {
            ScheduleRequest<bool> request = new ScheduleRequest<bool>();
            request.Url = baseUrl + "/Schedule";
            bool result = await request.SubmitDataJson(Method.POST, JsonConvert.SerializeObject(s));
            return result;
        }

        public async Task<bool> EditSchedule(ScheduleDto s)
        {
            ScheduleRequest<bool> request = new ScheduleRequest<bool>();
            request.Url = baseUrl + "/Schedule";
            bool result = await request.SubmitDataJson(Method.PUT, JsonConvert.SerializeObject(s));
            return result;
        }


        /// <summary>
        /// Return 0 if flight don't exist, other return schedule id
        /// </summary>
        public async Task<int> FindFlightID(string _date,string _flightnumber)
        {
            ScheduleRequest<int> request = new ScheduleRequest<int>();
            request.Url = baseUrl + "/Schedule/FindFlight";
            object body = new
            {
                date = _date,
                flightnumber = _flightnumber
            };
            int re = await request.SubmitData(Method.POST, body);
            return re;
        }

        public async Task<List<int>> ImportCsv(List<ScheduleDto> _scheduleDtos)
        {
            ScheduleRequest<List<int>> request = new ScheduleRequest<List<int>>();
            request.Url = baseUrl + "/Schedule/Import";
            List<int> re = await request.SubmitDataJson(Method.POST, JsonConvert.SerializeObject(_scheduleDtos));            
            return re;
        }
    }
}
