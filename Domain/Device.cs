using GeoApp.Infrastructure.Repositories.Project;
using System.Data;

namespace GeoApp.Domain
{
    public class Device
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CalibrationInfo { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
}
