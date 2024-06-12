using GeoApp.Domain;
using System;
using System.Windows;


namespace GeoApp.Presentation.EditArea
{
    public partial class EditAreaWindow : Window
    {
        private Domain.Area area;

        public EditAreaWindow(Domain.Area area)
        {
            InitializeComponent();
            this.area = area;

            textBoxName.Text = area.Name;
            textBoxTopLeftLongitude.Text = area.TopLeftLongitude.ToString();
            textBoxTopRightLatitude.Text = area.TopRightLatitude.ToString();
            textBoxTopRightLongitude.Text = area.TopRightLongitude.ToString();
            textBoxBottomLeftLatitude.Text = area.BottomLeftLatitude.ToString();
            textBoxBottomLeftLongitude.Text = area.BottomLeftLongitude.ToString();
            textBoxBottomRightLatitude.Text = area.BottomRightLatitude.ToString();
            textBoxBottomRightLongitude.Text = area.BottomRightLongitude.ToString();
        }

        public Domain.Area GetUpdatedArea()
        {
            Domain.Area updatedArea = new Domain.Area
            {
                Id = area.Id,
                Name = textBoxName.Text,
                TopLeftLatitude = Convert.ToDouble(textBoxTopLeftLatitude.Text),
                TopLeftLongitude = Convert.ToDouble(textBoxTopLeftLongitude.Text),
                TopRightLatitude = Convert.ToDouble(textBoxTopRightLatitude.Text),
                TopRightLongitude = Convert.ToDouble(textBoxTopRightLongitude.Text),
                BottomLeftLatitude = Convert.ToDouble(textBoxBottomLeftLatitude.Text),
                BottomLeftLongitude = Convert.ToDouble(textBoxBottomLeftLongitude.Text),
                BottomRightLatitude = Convert.ToDouble(textBoxBottomRightLatitude.Text),
                BottomRightLongitude = Convert.ToDouble(textBoxBottomRightLongitude.Text)
            };

            return updatedArea;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                area.Name = textBoxName.Text;
                area.TopLeftLatitude = Convert.ToDouble(textBoxTopLeftLatitude.Text);
                area.TopLeftLongitude = Convert.ToDouble(textBoxTopLeftLongitude.Text);
                area.TopRightLatitude = Convert.ToDouble(textBoxTopRightLatitude.Text);
                area.TopRightLongitude = Convert.ToDouble(textBoxTopRightLongitude.Text);
                area.BottomLeftLatitude = Convert.ToDouble(textBoxBottomLeftLatitude.Text);
                area.BottomLeftLongitude = Convert.ToDouble(textBoxBottomLeftLongitude.Text);
                area.BottomRightLatitude = Convert.ToDouble(textBoxBottomRightLatitude.Text);
                area.BottomRightLongitude = Convert.ToDouble(textBoxBottomRightLongitude.Text);

                DialogResult = true;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Пожалуйста, введите название площади.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            double value;
            if (!double.TryParse(textBoxTopLeftLatitude.Text, out value) ||
                !double.TryParse(textBoxTopLeftLongitude.Text, out value) ||
                !double.TryParse(textBoxTopRightLatitude.Text, out value) ||
                !double.TryParse(textBoxTopRightLongitude.Text, out value) ||
                !double.TryParse(textBoxBottomLeftLatitude.Text, out value) ||
                !double.TryParse(textBoxBottomLeftLongitude.Text, out value) ||
                !double.TryParse(textBoxBottomRightLatitude.Text, out value) ||
                !double.TryParse(textBoxBottomRightLongitude.Text, out value))
            {
                MessageBox.Show("Пожалуйста, введите допустимые числовые значения в поля широты и долготы.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
