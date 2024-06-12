using GeoApp.Infrastructure.Repositories.AreaLine;
using GeoApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApp.Application.AreaLine
{
    public class AreaLineService
    {
        private static AreaLineService instance;
        private readonly AreaLineRepository _areaLineRepository;

        public AreaLineService(AreaLineRepository areaLineRepository)
        {
            _areaLineRepository = areaLineRepository;
            instance = this;
        }

        public static AreaLineService GetInstance()
        {
            return instance;
        }

        public List<Domain.AreaLine> GetAreaLinesForArea(int areaId)
        {
            return _areaLineRepository.GetAreaLinesForArea(areaId);
        }

        public void AddAreaLine(int areaId, string name, double topLeftLatitude, double topLeftLongitude,
            double topRightLatitude, double topRightLongitude, double bottomLeftLatitude, double bottomLeftLongitude,
            double bottomRightLatitude, double bottomRightLongitude)
        {
            Domain.AreaLine areaLine = new Domain.AreaLine
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

            _areaLineRepository.AddAreaLine(areaId, areaLine);
        }

        public void UpdateAreaLine(Domain.AreaLine areaLine)
        {
            _areaLineRepository.UpdateAreaLine(areaLine);
        }

        public void DeleteAreaLine(int areaLineId)
        {
            _areaLineRepository.DeleteAreaLine(areaLineId);
        }
    }
}
