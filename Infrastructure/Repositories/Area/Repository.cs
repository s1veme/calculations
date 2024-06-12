using System;
using System.Collections.Generic;
using System.Data;

namespace GeoApp.Infrastructure.Repositories.Area
{
    public class AreaRepository
    {
        private readonly Database _database;

        public AreaRepository(Database database)
        {
            _database = database;
        }

        public List<Domain.Area> GetAllAreas()
        {
            var query = "SELECT * FROM areas";
            var dataTable = _database.Select(query, new Dictionary<string, object>());

            var areas = new List<Domain.Area>();
            foreach (DataRow row in dataTable.Rows)
            {
                areas.Add(new Domain.Area
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    TopLeftLatitude = Convert.ToDouble(row["top_left_lat"]),
                    TopLeftLongitude = Convert.ToDouble(row["top_left_lon"]),
                    TopRightLatitude = Convert.ToDouble(row["top_right_lat"]),
                    TopRightLongitude = Convert.ToDouble(row["top_right_lon"]),
                    BottomLeftLatitude = Convert.ToDouble(row["bottom_left_lat"]),
                    BottomLeftLongitude = Convert.ToDouble(row["bottom_left_lon"]),
                    BottomRightLatitude = Convert.ToDouble(row["bottom_right_lat"]),
                    BottomRightLongitude = Convert.ToDouble(row["bottom_right_lon"])
                });
            }
            return areas;
        }

        public List<Domain.Area> GetAreasForProject(int projectId)
        {
            var query = @"SELECT a.*
                      FROM areas a
                      INNER JOIN project_areas pa ON a.id = pa.area_id
                      WHERE pa.project_id = @projectId";
            var parameters = new Dictionary<string, object>
        {
            { "@projectId", projectId }
        };
            var dataTable = _database.Select(query, parameters);

            var areas = new List<Domain.Area>();
            foreach (DataRow row in dataTable.Rows)
            {
                areas.Add(new Domain.Area
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    TopLeftLatitude = Convert.ToDouble(row["top_left_lat"]),
                    TopLeftLongitude = Convert.ToDouble(row["top_left_lon"]),
                    TopRightLatitude = Convert.ToDouble(row["top_right_lat"]),
                    TopRightLongitude = Convert.ToDouble(row["top_right_lon"]),
                    BottomLeftLatitude = Convert.ToDouble(row["bottom_left_lat"]),
                    BottomLeftLongitude = Convert.ToDouble(row["bottom_left_lon"]),
                    BottomRightLatitude = Convert.ToDouble(row["bottom_right_lat"]),
                    BottomRightLongitude = Convert.ToDouble(row["bottom_right_lon"])
                });
            }
            return areas;
        }

        public void AddArea(int projectID, Domain.Area area)
        {
            var queryInsertArea = @"INSERT INTO areas (name, top_left_lat, top_left_lon, top_right_lat, top_right_lon, 
                                              bottom_left_lat, bottom_left_lon, bottom_right_lat, bottom_right_lon)
                            VALUES (@name, @topLeftLatitude, @topLeftLongitude, @topRightLatitude, @topRightLongitude,
                                    @bottomLeftLatitude, @bottomLeftLongitude, @bottomRightLatitude, @bottomRightLongitude)
                            RETURNING id";
            var parametersInsertArea = new Dictionary<string, object>
            {
                { "@name", area.Name },
                { "@topLeftLatitude", area.TopLeftLatitude },
                { "@topLeftLongitude", area.TopLeftLongitude },
                { "@topRightLatitude", area.TopRightLatitude },
                { "@topRightLongitude", area.TopRightLongitude },
                { "@bottomLeftLatitude", area.BottomLeftLatitude },
                { "@bottomLeftLongitude", area.BottomLeftLongitude },
                { "@bottomRightLatitude", area.BottomRightLatitude },
                { "@bottomRightLongitude", area.BottomRightLongitude }
            };
            var newAreaId = Convert.ToInt32(_database.QueryScalar(queryInsertArea, parametersInsertArea));

            var queryInsertProjectArea = @"INSERT INTO project_areas (project_id, area_id)
                                    VALUES (@projectId, @areaId)";
            var parametersInsertProjectArea = new Dictionary<string, object>
            {
                { "@projectId", projectID },
                { "@areaId", newAreaId }
            };
            _database.Query(queryInsertProjectArea, parametersInsertProjectArea);
        }

        public void UpdateArea(Domain.Area area)
        {
            var query = @"UPDATE areas 
                      SET name = @name, top_left_lat = @topLeftLatitude, top_left_lon = @topLeftLongitude,
                          top_right_lat = @topRightLatitude, top_right_lon = @topRightLongitude,
                          bottom_left_lat = @bottomLeftLatitude, bottom_left_lon = @bottomLeftLongitude,
                          bottom_right_lat = @bottomRightLatitude, bottom_right_lon = @bottomRightLongitude
                      WHERE id = @id";
            var parameters = new Dictionary<string, object>
        {
            { "@id", area.Id },
            { "@name", area.Name },
            { "@topLeftLatitude", area.TopLeftLatitude },
            { "@topLeftLongitude", area.TopLeftLongitude },
            { "@topRightLatitude", area.TopRightLatitude },
            { "@topRightLongitude", area.TopRightLongitude },
            { "@bottomLeftLatitude", area.BottomLeftLatitude },
            { "@bottomLeftLongitude", area.BottomLeftLongitude },
            { "@bottomRightLatitude", area.BottomRightLatitude },
            { "@bottomRightLongitude", area.BottomRightLongitude }
        };
            _database.Query(query, parameters);
        }

        public void DeleteArea(int id)
        {
            var query = "DELETE FROM areas WHERE id = @id";
            var parameters = new Dictionary<string, object>
        {
            { "@id", id }
        };
            _database.Query(query, parameters);
        }
    }
}
