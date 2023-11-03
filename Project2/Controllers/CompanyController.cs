using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using DAL.Entities;
using System.Linq;
using TTask = System.Threading.Tasks.Task;

namespace Project2.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var companies = _companyService.GetAllCompanies().ToList();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _companyService.AddCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _companyService.UpdateCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public IActionResult Delete(int id)
        {
            var company = _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _companyService.DeleteCompany(id);
            return RedirectToAction("Index");
        }
        public IActionResult Employees(int id)
        {
            // Получите список сотрудников для определенной компании по id
            var employees = _companyService.GetEmployeesByCompanyId(id);
            return View(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(int companyId, int employeeId)
        {
            // Добавьте сотрудника к компании
            _companyService.AddEmployeeToCompany(companyId, employeeId);
            return RedirectToAction("Employees", new { id = companyId });
        }

        [HttpPost]
        public IActionResult RemoveEmployee(int companyId, int employeeId)
        {
            // Удалите сотрудника из компании
            _companyService.RemoveEmployeeFromCompany(companyId, employeeId);
            return RedirectToAction("Employees", new { id = companyId });
        }

    }

    // TODO: Function to Add employees 

    // TODO: Function to Add projects

}

