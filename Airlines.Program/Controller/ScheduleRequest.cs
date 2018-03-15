using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Program.Controller
{
    public class ScheduleRequest<T>
    {
        private RestClient client;
        private RestRequest request;
        public string Url { get; set; }

        /// <summary>
        /// using <see cref="RestSharp.RestRequest.AddBody(object)"/>
        /// </summary>
        public async Task<T> SubmitData(RestSharp.Method method,object body)
        {
            client = new RestClient(Url);
            request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);

            IRestResponse<T> response =
                await client.ExecuteTaskAsync<T>(request);
            return response.Data;
        }

        /// <summary>
        /// using raw JSON
        /// </summary>
        public async Task<T> SubmitDataJson(RestSharp.Method method, string json)
        {
            client = new RestClient(Url);
            request = new RestRequest(method);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json",json,ParameterType.RequestBody);

            IRestResponse<T> response =
                await client.ExecuteTaskAsync<T>(request);
            return response.Data;
        }

        public async Task<T> GetData()
        {
            client = new RestClient(Url);
            request = new RestRequest(Method.GET);
            IRestResponse<T> response =
                await client.ExecuteTaskAsync<T>(request);
            return response.Data;
        }
    }
}
