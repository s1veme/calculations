using System;
using System.Collections.Generic;
using System.Data;

namespace GeoApp.Infrastructure.Repositories.Device
{
    public class DeviceRepository
    {
        private readonly Database _database;

        public DeviceRepository(Database database)
        {
            _database = database;
        }

        public List<Domain.Device> GetAllDevices()
        {
            List<Domain.Device> devices = new List<Domain.Device>();

            DataTable dataTable = _database.Select("SELECT * FROM devices", new Dictionary<string, object>());

            foreach (DataRow row in dataTable.Rows)
            {
                devices.Add(new DeviceModel
                {
                    ID = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    CalibrationInfo = row["calibration_info"].ToString(),
                    Manufacturer = row["manufacturer"].ToString(),
                    Model = row["model"].ToString()
                }.ToDomain());
            }

            return devices;
        }

        public void AddDevice(Domain.Device device)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"Name", device.Name},
                {"CalibrationInfo", device.CalibrationInfo},
                {"Manufacturer", device.Manufacturer},
                {"Model", device.Model}
            };

            _database.Query("INSERT INTO devices (name, calibration_info, manufacturer, model) VALUES (@Name, @CalibrationInfo, @Manufacturer, @Model)", parameters);
        }

        public void UpdateDevice(Domain.Device device)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"Name", device.Name},
                {"CalibrationInfo", device.CalibrationInfo},
                {"Manufacturer", device.Manufacturer},
                {"Model", device.Model},
                {"ID", device.ID}
            };

            _database.Query("UPDATE devices SET name = @Name, calibration_info = @CalibrationInfo, manufacturer = @Manufacturer, model = @Model WHERE id = @ID", parameters);
        }

        public void DeleteDevice(int deviceID)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"ID", deviceID}
            };

            _database.Query("DELETE FROM devices WHERE id = @ID", parameters);
        }
    }
}
