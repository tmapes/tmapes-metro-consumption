using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace tmapes_metro_consumption.Models
{
    public class TimepointDepartureModel
    {
        public bool Actual { get; set; }
        public int BlockNumber { get; set; }
        public string DepartureText { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Description { get; set; }
        public string Gate { get; set; }
        public string RouteDirection { get; set; }
        public string Terminal { get; set; }
        public int VehicleHeading { get; set; }
        public double VehicleLatitude { get; set;}
        public double VehicleLongitude { get; set; }
    }
}
