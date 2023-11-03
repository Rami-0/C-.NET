using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using DAL.Entities;
using System.Linq;

namespace Project2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;

        public EmployeeController(IEmployeeService employeeService, ICompanyService companyService)
        {
            _employeeService = employeeService;
            _companyService = companyService;
        }

        // Список всех сотрудников
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees().ToList();
            return View(employees);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // Удаление сотрудника
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public IActionResult Companies(int id)
        {
            // Получите список компаний, в которых работает сотрудник по id
            var companies = _employeeService.GetCompaniesByEmployeeId(id);
            return View(companies);
        }
        [HttpPost]
        public IActionResult AddToCompany(int employeeId, int companyId)
        {
            // Получите сотрудника по employeeId
            var employee = _employeeService.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            // Получите компанию по companyId
            // Получите компанию по companyId
            var company = _companyService.GetCompanyById(companyId);

            if (company == null)
            {
                return NotFound();
            }

            // Установите отношение между сотрудником и компанией
            company.Employees.Add(employee);

            // Сохраните изменения в базе данных
            _companyService.UpdateCompany(company);

            // Верните ответ или перенаправьтесь, в зависимости от вашего сценария

            return RedirectToAction("Index");
        }

        // Редактирование сотрудника в компании
        [HttpPost]
        public IActionResult EditInCompany(int employeeId, int companyId)
        {
            // Получите сотрудника по employeeId
            var employee = _employeeService.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return NotFound();
            }
            // Получите компанию по companyId
            var company = _companyService.GetCompanyById(companyId);

            if (company == null)
            {
                return NotFound();
            }
            return View();
        }

        // Logic to add task for employee // ..../employee/:id/tasks

        // Logic to submit tasks :: Завершить
    }
}
