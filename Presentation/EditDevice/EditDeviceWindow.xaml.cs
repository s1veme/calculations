using System.Windows;


namespace GeoApp.Presentation.EditDevice
{
    public partial class EditDeviceWindow : Window
    {
        private readonly Domain.Device _device;

        public EditDeviceWindow(Domain.Device device)
        {
            InitializeComponent();
            _device = device;
            textBoxName.Text = _device.Name;
            textBoxCalibrationInfo.Text = _device.CalibrationInfo;
            textBoxManufacturer.Text = _device.Manufacturer;
            textBoxModel.Text = _device.Model;
        }

        public Domain.Device GetUpdatedDevice()
        {
            return new Domain.Device
            {
                ID = _device.ID,
                Name = textBoxName.Text,
                CalibrationInfo = textBoxCalibrationInfo.Text,
                Manufacturer = textBoxManufacturer.Text,
                Model = textBoxModel.Text
            };
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
