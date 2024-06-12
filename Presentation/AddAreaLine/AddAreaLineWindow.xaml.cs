using System.Windows;


namespace GeoApp.Presentation.AddAreaLine
{
    public partial class AddAreaLineWindow : Window
    {
        public AddAreaLineWindow()
        {
            InitializeComponent();
        }

        public string GetName() => textBoxName.Text;
        public double GetTopLeftLatitude() => double.Parse(textBoxTopLeftLatitude.Text);
        public double GetTopLeftLongitude() => double.Parse(textBoxTopLeftLongitude.Text);
        public double GetTopRightLatitude() => double.Parse(textBoxTopRightLatitude.Text);
        public double GetTopRightLongitude() => double.Parse(textBoxTopRightLongitude.Text);
        public double GetBottomLeftLatitude() => double.Parse(textBoxBottomLeftLatitude.Text);
        public double GetBottomLeftLongitude() => double.Parse(textBoxBottomLeftLongitude.Text);
        public double GetBottomRightLatitude() => double.Parse(textBoxBottomRightLatitude.Text);
        public double GetBottomRightLongitude() => double.Parse(textBoxBottomRightLongitude.Text);

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
