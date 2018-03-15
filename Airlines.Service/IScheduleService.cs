using Airlines.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Airlines.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScheduleService" in both code and config file together.
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "/Schedule/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        ScheduleDto ScheduleById(string id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Schedule/List",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        List<ScheduleDto> ListScheduleFilter(string from, string to, string date,
            string flightnumber, string sortBy, bool descending);

        
        [OperationContract]
        [WebGet(
            UriTemplate = "/Schedule/Airport",
            ResponseFormat = WebMessageFormat.Json)]
        List<string> AirportList();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Schedule",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        bool AddSchedule(ScheduleDto scheduleDto);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Schedule",
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json)]
        bool EditSchedule(ScheduleDto scheduleDto);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Schedule/Flight",
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json)]
        bool CancelFlight(int id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Schedule/FindFlight",
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json)]
        int FindFlight(string date, string flightnumber);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "/Schedule/Import",
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json)]
        List<int> ImportService(List<ScheduleDto> scheduleDtos);

    }
}
