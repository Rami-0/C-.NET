using DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IGenericRepository<Task> _repository;

        public TaskService(IGenericRepository<Task> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Task> GetAllTasks() => _repository.GetAll();

        public Task GetTaskById(int id) => _repository.GetById(id);

        public void AddTask(Task task) => _repository.Add(task);

        public void UpdateTask(Task task) => _repository.Update(task);

        public void DeleteTask(int id) => _repository.Delete(id);
    }
}
