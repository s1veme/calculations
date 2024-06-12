using System;
using System.Collections.Generic;
using System.Data;

namespace GeoApp.Infrastructure.Repositories.AreaLine
{
    public class AreaLineRepository
    {
        private readonly Database _database;

        public AreaLineRepository(Database database)
        {
            _database = database;
        }

        public List<Domain.AreaLine> GetAreaLinesForArea(int areaId)
        {
            var query = @"SELECT al.*
                          FROM area_lines al
                          INNER JOIN area_lines_areas ala ON al.id = ala.area_line_id
                          WHERE ala.area_id = @areaId";
            var parameters = new Dictionary<string, object>
            {
                { "@areaId", areaId }
            };
            var dataTable = _database.Select(query, parameters);

            var areaLines = new List<Domain.AreaLine>();
            foreach (DataRow row in dataTable.Rows)
            {
                areaLines.Add(new Domain.AreaLine
                {
                    Id = (int)row["id"],
                    Name = row["name"].ToString(),
                    TopLeftLatitude = (double)row["top_left_lat"],
                    TopLeftLongitude = (double)row["top_left_lon"],
                    TopRightLatitude = (double)row["top_right_lat"],
                    TopRightLongitude = (double)row["top_right_lon"],
                    BottomLeftLatitude = (double)row["bottom_left_lat"],
                    BottomLeftLongitude = (double)row["bottom_left_lon"],
                    BottomRightLatitude = (double)row["bottom_right_lat"],
                    BottomRightLongitude = (double)row["bottom_right_lon"]
                });
            }
            return areaLines;
        }

        public void AddAreaLine(int areaId, Domain.AreaLine areaLine)
        {
            var query = @"INSERT INTO area_lines (name, top_left_lat, top_left_lon, top_right_lat, top_right_lon, 
                      bottom_left_lat, bottom_left_lon, bottom_right_lat, bottom_right_lon)
                      VALUES (@name, @topLeftLatitude, @topLeftLongitude, @topRightLatitude, @topRightLongitude, 
                      @bottomLeftLatitude, @bottomLeftLongitude, @bottomRightLatitude, @bottomRightLongitude);
                      SELECT lastval()";

            var parameters = new Dictionary<string, object>
        {
            { "@name", areaLine.Name },
            { "@topLeftLatitude", areaLine.TopLeftLatitude },
            { "@topLeftLongitude", areaLine.TopLeftLongitude },
            { "@topRightLatitude", areaLine.TopRightLatitude },
            { "@topRightLongitude", areaLine.TopRightLongitude },
            { "@bottomLeftLatitude", areaLine.BottomLeftLatitude },
            { "@bottomLeftLongitude", areaLine.BottomLeftLongitude },
            { "@bottomRightLatitude", areaLine.BottomRightLatitude },
            { "@bottomRightLongitude", areaLine.BottomRightLongitude }
        };

            int areaLineId = Convert.ToInt32(_database.QueryScalar(query, parameters));

            var linkQuery = @"INSERT INTO area_lines_areas (area_id, area_line_id) VALUES (@areaId, @areaLineId)";
            var linkParameters = new Dictionary<string, object>
        {
            { "@areaId", areaId },
            { "@areaLineId", areaLineId }
        };

            _database.Query(linkQuery, linkParameters);
        }

        public void UpdateAreaLine(Domain.AreaLine areaLine)
        {
            var query = @"UPDATE area_lines 
                      SET name = @name, 
                          top_left_lat = @topLeftLatitude, 
                          top_left_lon = @topLeftLongitude,
                          top_right_lat = @topRightLatitude,
                          top_right_lon = @topRightLongitude,
                          bottom_left_lat = @bottomLeftLatitude,
                          bottom_left_lon = @bottomLeftLongitude,
                          bottom_right_lat = @bottomRightLatitude,
                          bottom_right_lon = @bottomRightLongitude
                      WHERE id = @id";

            var parameters = new Dictionary<string, object>
        {
            { "@id", areaLine.Id },
            { "@name", areaLine.Name },
            { "@topLeftLatitude", areaLine.TopLeftLatitude },
            { "@topLeftLongitude", areaLine.TopLeftLongitude },
            { "@topRightLatitude", areaLine.TopRightLatitude },
            { "@topRightLongitude", areaLine.TopRightLongitude },
            { "@bottomLeftLatitude", areaLine.BottomLeftLatitude },
            { "@bottomLeftLongitude", areaLine.BottomLeftLongitude },
            { "@bottomRightLatitude", areaLine.BottomRightLatitude },
            { "@bottomRightLongitude", areaLine.BottomRightLongitude }
        };

            _database.Query(query, parameters);
        }

        public void DeleteAreaLine(int areaLineId)
        {
            var query = "DELETE FROM area_lines WHERE id = @id";
            var parameters = new Dictionary<string, object>
        {
            { "@id", areaLineId }
        };

            _database.Query(query, parameters);
        }
    }
}
