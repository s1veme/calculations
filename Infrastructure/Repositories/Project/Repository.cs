using System;
using System.Collections.Generic;
using System.Data;

namespace GeoApp.Infrastructure.Repositories.Project
{
    public class ProjectRepository
    {
        private readonly Database _database;

        public ProjectRepository(Database database)
        {
            _database = database;
        }

        public List<Domain.Project> GetAllProjects()
        {
            List<Domain.Project> projects = new List<Domain.Project>();

            DataTable dataTable = _database.Select("SELECT * FROM projects", new Dictionary<string, object>());

            foreach (DataRow row in dataTable.Rows)
            {
                projects.Add(new Domain.Project
                {
                    ID = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    CustomerID = Convert.ToInt32(row["customer_id"]),
                    StartDate = Convert.ToDateTime(row["start_date"]),
                    EndDate = Convert.ToDateTime(row["end_date"])
                });
            }

            return projects;
        }

        public void AddProject(Domain.Project project)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"Name", project.Name},
                {"CustomerID", project.CustomerID},
                {"StartDate", project.StartDate},
                {"EndDate", project.EndDate}
            };

            _database.Query("INSERT INTO projects (name, customer_id, start_date, end_date) VALUES (@Name, @CustomerID, @StartDate, @EndDate)", parameters);
        }

        public void UpdateProject(Domain.Project project)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"Name", project.Name},
                {"CustomerID", project.CustomerID},
                {"StartDate", project.StartDate},
                {"EndDate", project.EndDate},
                {"ID", project.ID}
            };

            _database.Query("UPDATE projects SET name = @Name, customer_id = @CustomerID, start_date = @StartDate, end_date = @EndDate WHERE id = @ID", parameters);
        }

        public void DeleteProject(int projectID)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"ID", projectID}
            };

            _database.Query("DELETE FROM projects WHERE id = @ID", parameters);
        }
    }
}
