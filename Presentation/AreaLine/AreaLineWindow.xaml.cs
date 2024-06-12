using GeoApp.Application.AreaLine;
using System.Collections.Generic;
using System.Windows;
using GeoApp.Presentation.AddAreaLine;
using GeoApp.Presentation.EditAreaLine;


namespace GeoApp.Presentation.AreaLine
{
    public partial class AreaLineWindow : Window
    {
        private readonly AreaLineService _areaLineService;
        private readonly Domain.Area _area;

        public AreaLineWindow(Domain.Area area)
        {
            InitializeComponent();
            _area = area;
            _areaLineService = AreaLineService.GetInstance();
            LoadAreaLines();
        }

        private void LoadAreaLines()
        {
            List<Domain.AreaLine> areaLines = _areaLineService.GetAreaLinesForArea(_area.Id);
            AreaLinesDataGrid.ItemsSource = areaLines;
        }

        private void AddLine(object sender, RoutedEventArgs e)
        {
            AddAreaLineWindow addAreaLineWindow = new AddAreaLineWindow();
            if (addAreaLineWindow.ShowDialog() == true)
            {
                _areaLineService.AddAreaLine(
                    _area.Id,
                    addAreaLineWindow.GetName(),
                    addAreaLineWindow.GetTopLeftLatitude(),
                    addAreaLineWindow.GetTopLeftLongitude(),
                    addAreaLineWindow.GetTopRightLatitude(),
                    addAreaLineWindow.GetTopRightLongitude(),
                    addAreaLineWindow.GetBottomLeftLatitude(),
                    addAreaLineWindow.GetBottomLeftLongitude(),
                    addAreaLineWindow.GetBottomRightLatitude(),
                    addAreaLineWindow.GetBottomRightLongitude()
                );

                LoadAreaLines();
            }
        }

        private void DeleteLine(object sender, RoutedEventArgs e)
        {
            if (AreaLinesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите линию измерений для удаления.");
                return;
            }

            Domain.AreaLine selectedAreaLine = (Domain.AreaLine)AreaLinesDataGrid.SelectedItem;
            if (MessageBox.Show($"Вы уверены, что хотите удалить линию измерений '{selectedAreaLine.Name}'?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _areaLineService.DeleteAreaLine(selectedAreaLine.Id);
                LoadAreaLines();
            }
        }

        private void EditLine(object sender, RoutedEventArgs e)
        {
            if (AreaLinesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите линию измерений для редактирования.");
                return;
            }

            Domain.AreaLine selectedAreaLine = (Domain.AreaLine)AreaLinesDataGrid.SelectedItem;

            EditAreaLineWindow editAreaLineWindow = new EditAreaLineWindow(selectedAreaLine);

            if (editAreaLineWindow.ShowDialog() == true)
            {
                Domain.AreaLine updatedAreaLine = editAreaLineWindow.GetUpdatedAreaLine();

                _areaLineService.UpdateAreaLine(updatedAreaLine);

                LoadAreaLines();
            }
        }

        private void OpenLineDetail(object sender, RoutedEventArgs e)
        {

        }
    }
}
