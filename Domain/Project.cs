using System;

namespace GeoApp.Domain
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
