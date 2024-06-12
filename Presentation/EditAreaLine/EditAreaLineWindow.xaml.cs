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

namespace GeoApp.Presentation.EditAreaLine
{
    public partial class EditAreaLineWindow : Window
    {
        private Domain.AreaLine areaLine;

        public EditAreaLineWindow(Domain.AreaLine areaLine)
        {
            InitializeComponent();

            this.areaLine = areaLine;

            textBoxName.Text = areaLine.Name;
            textBoxTopLeftLatitude.Text = areaLine.TopLeftLatitude.ToString();
            textBoxTopLeftLongitude.Text = areaLine.TopLeftLongitude.ToString();
            textBoxTopRightLatitude.Text = areaLine.TopRightLatitude.ToString();
            textBoxTopRightLongitude.Text = areaLine.TopRightLongitude.ToString();
            textBoxBottomLeftLatitude.Text = areaLine.BottomLeftLatitude.ToString();
            textBoxBottomLeftLongitude.Text = areaLine.BottomLeftLongitude.ToString();
            textBoxBottomRightLatitude.Text = areaLine.BottomRightLatitude.ToString();
            textBoxBottomRightLongitude.Text = areaLine.BottomRightLongitude.ToString();
        }

        public Domain.AreaLine GetUpdatedAreaLine()
        {
            return new Domain.AreaLine
            {
                Id = areaLine.Id,
                Name = textBoxName.Text,
                TopLeftLatitude = double.Parse(textBoxTopLeftLatitude.Text),
                TopLeftLongitude = double.Parse(textBoxTopLeftLongitude.Text),
                TopRightLatitude = double.Parse(textBoxTopRightLatitude.Text),
                TopRightLongitude = double.Parse(textBoxTopRightLongitude.Text),
                BottomLeftLatitude = double.Parse(textBoxBottomLeftLatitude.Text),
                BottomLeftLongitude = double.Parse(textBoxBottomLeftLongitude.Text),
                BottomRightLatitude = double.Parse(textBoxBottomRightLatitude.Text),
                BottomRightLongitude = double.Parse(textBoxBottomRightLongitude.Text)
            };
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
