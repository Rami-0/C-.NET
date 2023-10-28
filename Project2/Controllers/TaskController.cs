using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using DAL.Entities;
using System.Linq;

namespace Project2.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var tasks = _service.GetAllTasks().ToList();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(System.Threading.Tasks.Task task)
        {
            if (ModelState.IsValid)
            {
                _service.AddTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = _service.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(int id, System.Threading.Tasks.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _service.UpdateTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _service.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteTask(id);
            return RedirectToAction("Index");
        }
     

    }
}
