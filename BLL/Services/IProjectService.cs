using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
    }
}
