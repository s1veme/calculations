using GeoApp.Application.Area;
using GeoApp.Domain;
using GeoApp.Presentation.AddArea;
using GeoApp.Presentation.AreaLine;
using GeoApp.Presentation.EditArea;
using System.Collections.Generic;
using System.Windows;


namespace GeoApp.Presentation.Area
{
    public partial class AreaWindow : Window
    {
        private readonly AreaService _areaService;
        private readonly Project _project;

        public AreaWindow(Project project)
        {
            InitializeComponent();
            _project = project;
            _areaService = AreaService.GetInstance();
            LoadAreas();
        }

        private void LoadAreas()
        {
            List<Domain.Area> areas = _areaService.GetAreasForProject(_project.ID);
            AreasDataGrid.ItemsSource = areas;
        }

        private void AddArea_Click(object sender, RoutedEventArgs e)
        {
            AddAreaWindow addAreaWindow = new AddAreaWindow();
            if (addAreaWindow.ShowDialog() == true)
            {
                _areaService.AddArea(
                    _project.ID,
                    addAreaWindow.GetName(),
                    addAreaWindow.GetTopLeftLatitude(),
                    addAreaWindow.GetTopLeftLongitude(),
                    addAreaWindow.GetTopRightLatitude(),
                    addAreaWindow.GetTopRightLongitude(),
                    addAreaWindow.GetBottomLeftLatitude(),
                    addAreaWindow.GetBottomLeftLongitude(),
                    addAreaWindow.GetBottomRightLatitude(),
                    addAreaWindow.GetBottomRightLongitude()
                );

                LoadAreas();
            }
        }

        private void DeleteArea_Click(object sender, RoutedEventArgs e)
        {
            if (AreasDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите площадь для удаления.");
                return;
            }

            Domain.Area selectedArea = (Domain.Area)AreasDataGrid.SelectedItem;
            if (MessageBox.Show($"Вы уверены, что хотите удалить площадь '{selectedArea.Name}'?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _areaService.DeleteArea(selectedArea.Id);
                LoadAreas();
            }
        }

        private void EditArea_Click(object sender, RoutedEventArgs e)
        {
            if (AreasDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите площадь для редактирования.");
                return;
            }

            Domain.Area selectedArea = (Domain.Area)AreasDataGrid.SelectedItem;

            EditAreaWindow editAreaWindow = new EditAreaWindow(selectedArea);

            if (editAreaWindow.ShowDialog() == true)
            {
                Domain.Area updatedArea = editAreaWindow.GetUpdatedArea();

                _areaService.UpdateArea(updatedArea);

                LoadAreas();
            }

        }

        private void OpenAreaDetail(object sender, RoutedEventArgs e)
        {
            if (AreasDataGrid.SelectedItem != null)
            {
                Domain.Area selectedArea = (Domain.Area)AreasDataGrid.SelectedItem;
                var window = new AreaLineWindow(selectedArea);
                window.Show();
            }
        }
    }
}
