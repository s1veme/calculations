using System;
using System.Diagnostics;
using System.Windows;
using GeoApp.Application.Device;
using GeoApp.Application.Project;
using GeoApp.Domain;
using GeoApp.Presentation.AddDevice;
using GeoApp.Presentation.AddProject;
using GeoApp.Presentation.Area;
using GeoApp.Presentation.EditDevice;
using GeoApp.Presentation.EditProject;


namespace GeoApp.Presentation.Main.View
{
    public partial class Main : Window
    {
        private readonly ProjectService _projectService;
        private readonly DeviceService _deviceService;

        public Main()
        {
            InitializeComponent();
            _projectService = ProjectService.GetInstance();
            _deviceService = DeviceService.GetInstance();

            CreateProjectsList();
            CreateDevicesList();
        }

        public void CreateProjectsList()
        {
            Debug.WriteLine(_projectService.GetAllProjects());
            ProjectsDataGrid.ItemsSource = _projectService.GetAllProjects();
        }

        public void CreateDevicesList()
        {
            DevicesDataGrid.ItemsSource = _deviceService.GetAllDevices();
        }

        private void AddProject(object sender, RoutedEventArgs e) {
            AddProjectWindow addProjectWindow = new AddProjectWindow();
            if (addProjectWindow.ShowDialog() != true)
            {
                return;
            }

            string name = addProjectWindow.GetName();
            int customerID = addProjectWindow.GetCustomerID();
            int measurementID = addProjectWindow.GetMeasurementID();
            DateTime startDate = addProjectWindow.GetStartDate();
            DateTime endDate = addProjectWindow.GetEndDate();

            _projectService.AddProject(new Project
            {
                Name = name,
                CustomerID = customerID,
                StartDate = startDate,
                EndDate = endDate,

            });

            CreateProjectsList();
        }

        private void EditProject(object sender, RoutedEventArgs e) {
            if (ProjectsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите проект для редактирования.");
            }

            Project selectedProject = (Project)ProjectsDataGrid.SelectedItem;

            EditProjectWindow editProjectWindow = new EditProjectWindow(selectedProject);
            if (editProjectWindow.ShowDialog() == true)
            {
                Project project = editProjectWindow.GetUpdatedProject();

                _projectService.UpdateProject(new Project
                {
                    ID = project.ID,
                    Name = project.Name,
                    CustomerID = project.CustomerID,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                });
                CreateProjectsList();
            }
        }

        private void DeleteProject(object sender, RoutedEventArgs e) {
            if (ProjectsDataGrid.SelectedItem != null)
            {
                Project selectedProject = (Project)ProjectsDataGrid.SelectedItem;
                if (MessageBox.Show($"Вы уверены, что хотите удалить проект '{selectedProject.Name}'?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _projectService.DeleteProject(selectedProject.ID);

                    CreateProjectsList();

                    return;
                }

                return;
            }


            MessageBox.Show("Выберите проект для удаления.");
        }

        private void OpenProjectDetail(object sender, RoutedEventArgs e) {
            if (ProjectsDataGrid.SelectedItem != null)
            {
                Project selectedProject = (Project)ProjectsDataGrid.SelectedItem;
                var window = new AreaWindow(selectedProject);
                window.Show();
            }
        }

        private void AddDevice(object sender, RoutedEventArgs e) {
            AddDeviceWindow addDeviceWindow = new AddDeviceWindow();
            if (addDeviceWindow.ShowDialog() == true)
            {
                _deviceService.AddDevice(new Domain.Device
                {
                    Name = addDeviceWindow.GetName(),
                    CalibrationInfo = addDeviceWindow.GetCalibrationInfo(),
                    Manufacturer = addDeviceWindow.GetManufacturer(),
                    Model = addDeviceWindow.GetModel()
                });

                CreateDevicesList();
            }
        }
        private void EditDevice(object sender, RoutedEventArgs e) {
            if (DevicesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите устройство для редактирования.");
                return;
            }

            Domain.Device selectedDevice = (Domain.Device)DevicesDataGrid.SelectedItem;

            EditDeviceWindow editDeviceWindow = new EditDeviceWindow(selectedDevice);
            if (editDeviceWindow.ShowDialog() == true)
            {
                Domain.Device updatedDevice = editDeviceWindow.GetUpdatedDevice();
                _deviceService.UpdateDevice(updatedDevice);
                CreateDevicesList();
            }
        }
        private void DeleteDevice(object sender, RoutedEventArgs e) {
            if (DevicesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите устройство для удаления.");
                return;
            }

            Domain.Device selectedDevice = (Domain.Device)DevicesDataGrid.SelectedItem;
            if (MessageBox.Show($"Вы уверены, что хотите удалить устройство '{selectedDevice.Name}'?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _deviceService.DeleteDevice(selectedDevice.ID);
                CreateDevicesList();
            }
        }

    }
}
