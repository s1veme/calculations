using GeoApp.Infrastructure.Repositories.Area;
using System;
using System.Collections.Generic;

namespace GeoApp.Application.Area
{
    public class AreaService
    {
        private readonly AreaRepository _areaRepository;

        private static AreaService instance;

        public static AreaService GetInstance()
        {
            return instance;
        }

        public AreaService(AreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
            instance = this;
        }

        public List<Domain.Area> GetAllAreas()
        {
            return _areaRepository.GetAllAreas();
        }

        public List<Domain.Area> GetAreasForProject(int projectId)
        {
            return _areaRepository.GetAreasForProject(projectId);
        }

        public void AddArea(int projectID, string name, double topLeftLatitude, double topLeftLongitude, double topRightLatitude, double topRightLongitude, double bottomLeftLatitude, double bottomLeftLongitude, double bottomRightLatitude, double bottomRightLongitude)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя площади должно быть заполнено.");
            }

            var area = new Domain.Area
            {
                Name = name,
                TopLeftLatitude = topLeftLatitude,
                TopLeftLongitude = topLeftLongitude,
                TopRightLatitude = topRightLatitude,
                TopRightLongitude = topRightLongitude,
                BottomLeftLatitude = bottomLeftLatitude,
                BottomLeftLongitude = bottomLeftLongitude,
                BottomRightLatitude = bottomRightLatitude,
                BottomRightLongitude = bottomRightLongitude
            };

            _areaRepository.AddArea(projectID, area);
        }

        public void UpdateArea(Domain.Area area)
        {
            if (string.IsNullOrEmpty(area.Name))
            {
                throw new ArgumentException("Имя площади должно быть заполнено.");
            }

            _areaRepository.UpdateArea(area);
        }

        public void DeleteArea(int id)
        {
            _areaRepository.DeleteArea(id);
        }
    }
}
