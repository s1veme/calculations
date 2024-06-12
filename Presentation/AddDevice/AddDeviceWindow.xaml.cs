using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GeoApp.Presentation.AddDevice
{
    public partial class AddDeviceWindow : Window
    {
        public AddDeviceWindow()
        {
            InitializeComponent();
        }

        public string GetName() => textBoxName.Text;
        public string GetCalibrationInfo() => textBoxCalibrationInfo.Text;
        public string GetManufacturer() => textBoxManufacturer.Text;
        public string GetModel() => textBoxModel.Text;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
