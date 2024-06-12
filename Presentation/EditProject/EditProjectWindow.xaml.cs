using GeoApp.Domain;
using System;
using System.Windows;

namespace GeoApp.Presentation.EditProject
{
    public partial class EditProjectWindow : Window
    {
        private Project project;

        public EditProjectWindow(Project project)
        {
            InitializeComponent();

            this.project = project;

            textBoxName.Text = project.Name;
            datePickerStartDate.SelectedDate = project.StartDate;
            datePickerEndDate.SelectedDate = project.EndDate;
        }

        public Project GetUpdatedProject()
        {
            return new Project
            {
                ID = project.ID,
                Name = textBoxName.Text,
                StartDate = datePickerStartDate.SelectedDate ?? DateTime.MinValue,
                EndDate = datePickerEndDate.SelectedDate ?? DateTime.MinValue,
                CustomerID = project.CustomerID,
            }; ;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
