using System;
using System.Windows;


namespace GeoApp.Presentation.AddProject
{
    public partial class AddProjectWindow : Window
    {
        public AddProjectWindow()
        {
            InitializeComponent();
        }

        public string GetName()
        {
            return textBoxName.Text;
        }

        public int GetCustomerID()
        {
            int customerID;
            if (int.TryParse(textBoxCustomerId.Text, out customerID))
            {
                return customerID;
            }
            return 0;
        }

        public int GetMeasurementID()
        {
            int measurementID;
            if (int.TryParse(textBoxMeasurementId.Text, out measurementID))
            {
                return measurementID;
            }
            return 0;
        }

        public DateTime GetStartDate()
        {
            return datePickerStartDate.SelectedDate ?? DateTime.MinValue;
        }

        public DateTime GetEndDate()
        {
            return datePickerEndDate.SelectedDate ?? DateTime.MinValue;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
