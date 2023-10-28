using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> _repository;

        public ProjectService(IGenericRepository<Project> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Project> GetAllProjects() => _repository.GetAll();

        public Project GetProjectById(int id) => _repository.GetById(id);

        public void AddProject(Project project) => _repository.Add(project);

        public void UpdateProject(Project project) => _repository.Update(project);

        public void DeleteProject(int id) => _repository.Delete(id);
    }
}
