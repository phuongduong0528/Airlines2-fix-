namespace Airlines.Business.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Schedule
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public int AircraftID { get; set; }

        public int RouteID { get; set; }

        [Column(TypeName = "money")]
        public decimal EconomyPrice { get; set; }

        public bool Confirmed { get; set; }

        [StringLength(10)]
        public string FlightNumber { get; set; }

        public virtual Aircraft Aircraft { get; set; }

        public virtual Route Route { get; set; }
    }
}
