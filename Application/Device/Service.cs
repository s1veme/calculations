using GeoApp.Application.Project;
using GeoApp.Infrastructure.Repositories.Device;
using System;
using System.Collections.Generic;


namespace GeoApp.Application.Device
{
    public class DeviceService
    {
        private readonly DeviceRepository _deviceRepository;

        private static DeviceService instance;

        public static DeviceService GetInstance()
        {
            return instance;
        }


        public DeviceService(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
            instance = this;
        }

        public List<Domain.Device> GetAllDevices()
        {
            return _deviceRepository.GetAllDevices();
        }

        public void AddDevice(Domain.Device device)
        {
            ValidateDeviceModel(device);

            _deviceRepository.AddDevice(device);
        }

        public void UpdateDevice(Domain.Device device)
        {
            ValidateDeviceModel(device);

            _deviceRepository.UpdateDevice(device);
        }

        public void DeleteDevice(int deviceID)
        {
            _deviceRepository.DeleteDevice(deviceID);
        }

        private void ValidateDeviceModel(Domain.Device device)
        {
            if (string.IsNullOrWhiteSpace(device.Name))
            {
                throw new ArgumentException("Имя прибора не может быть пустым.");
            }
        }
    }
}
