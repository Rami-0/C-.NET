using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using DAL.Entities;
using System.Linq;

namespace Project2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // Список всех сотрудников
        public IActionResult Index()
        {
            var employees = _service.GetAllEmployees().ToList();
            return View(employees);
        }

        // Форма создания сотрудника
        public IActionResult Create()
        {
            return View();
        }

        // Создание сотрудника
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _service.AddEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // Форма редактирования сотрудника
        public IActionResult Edit(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // Редактирование сотрудника
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // Форма удаления сотрудника
        public IActionResult Delete(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // Удаление сотрудника
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        // Logic to add task for employee // ..../employee/:id/tasks

        // Logic to submit tasks :: Завершить
    }
}
