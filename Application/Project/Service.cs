using GeoApp.Infrastructure.Repositories.Project;
using System;
using System.Collections.Generic;

namespace GeoApp.Application.Project
{
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;
        private static ProjectService instance;

        public static ProjectService GetInstance()
        {
            return instance;
        }


        public ProjectService(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            instance = this;
        }

        public List<Domain.Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }

        public void AddProject(Domain.Project project)
        {
            ValidateProject(project);

            _projectRepository.AddProject(project);
        }

        public void UpdateProject(Domain.Project project)
        {
            ValidateProject(project);

            _projectRepository.UpdateProject(project);
        }

        public void DeleteProject(int projectId)
        {
            _projectRepository.DeleteProject(projectId);
        }

        private void ValidateProject(Domain.Project project)
        {
            if (string.IsNullOrWhiteSpace(project.Name))
            {
                throw new ArgumentException("Название проекта не может быть пустым.");
            }
        }
    }
}
