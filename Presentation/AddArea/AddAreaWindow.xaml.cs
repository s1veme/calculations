using System.Windows;


namespace GeoApp.Presentation.AddArea
{
    public partial class AddAreaWindow : Window
    {
        public AddAreaWindow()
        {
            InitializeComponent();
        }

        public string GetName()
        {
            return textBoxName.Text;
        }

        public double GetTopLeftLatitude()
        {
            double.TryParse(textBoxTopLeftLatitude.Text, out double value);
            return value;
        }

        public double GetTopLeftLongitude()
        {
            double.TryParse(textBoxTopLeftLongitude.Text, out double value);
            return value;
        }

        public double GetTopRightLatitude()
        {
            double.TryParse(textBoxTopRightLatitude.Text, out double value);
            return value;
        }

        public double GetTopRightLongitude()
        {
            double.TryParse(textBoxTopRightLongitude.Text, out double value);
            return value;
        }

        public double GetBottomLeftLatitude()
        {
            double.TryParse(textBoxBottomLeftLatitude.Text, out double value);
            return value;
        }

        public double GetBottomLeftLongitude()
        {
            double.TryParse(textBoxBottomLeftLongitude.Text, out double value);
            return value;
        }

        public double GetBottomRightLatitude()
        {
            double.TryParse(textBoxBottomRightLatitude.Text, out double value);
            return value;
        }

        public double GetBottomRightLongitude()
        {
            double.TryParse(textBoxBottomRightLongitude.Text, out double value);
            return value;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
