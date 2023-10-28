using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(int id);
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int id);
    }
}
