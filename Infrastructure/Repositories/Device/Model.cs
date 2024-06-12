using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApp.Infrastructure.Repositories.Device
{
    public class DeviceModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CalibrationInfo { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public Domain.Device ToDomain()
        {
            return new Domain.Device
            {
                ID = this.ID,
                Name = this.Name,
                CalibrationInfo = this.CalibrationInfo,
                Manufacturer = this.Manufacturer,
                Model = this.Model
            };
        }
    }
}
