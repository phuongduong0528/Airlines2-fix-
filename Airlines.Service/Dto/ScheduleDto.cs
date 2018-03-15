using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Service.Dto
{
    [DataContract]
    public class ScheduleDto
    {
        [DataMember(Order = 0,Name = "id")]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DataMember(Order = 1, Name = "date")]
        [DisplayName("Date")]
        public string Date { get; set; }

        [DataMember(Order = 2, Name = "time")]
        [DisplayName("Time")]
        public string Time { get; set; }

        [DataMember(Order = 3, Name = "from")]
        [DisplayName("From")]
        public string From { get; set; }

        [DataMember(Order = 4, Name = "to")]
        [DisplayName("To")]
        public string To { get; set; }

        [DataMember(Order = 5, Name = "flightnumber")]
        [DisplayName("Flight number")]
        public string FlightNumber { get; set; }

        [DataMember(Order = 6, Name = "totalseats")]
        [DisplayName("Total seats")]
        public int TotalSeats { get; set; }

        [DataMember(Order = 7, Name = "economyprice")]
        [DisplayName("Economy price")]
        public decimal EconomyPrice { get; set; }
        
        [DataMember(Order = 8,Name = "businessprice")]
        [DisplayName("Business price")]
        public decimal BusinessPrice { get; set; }

        [DataMember(Order = 9, Name = "firstclassprice")]
        [DisplayName("First class price")]
        public decimal FirstClassPrice { get; set; }

        [DataMember(Order = 10, Name = "confirmed")]
        [DisplayName("Confirmed")]
        public bool Confirmed { get; set; }

        [DataMember(Order = 11, Name = "aircraftid")]
        [DisplayName("AircraftID")]
        public int AircraftID { get; set; }

        [DataMember(Order = 12, Name = "aircraftname")]
        [DisplayName("Aircraft name")]
        public string AircraftName { get; set; }
    }
}
