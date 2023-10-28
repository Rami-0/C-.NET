using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using DAL.Entities;
using System.Linq;
using TTask = System.Threading.Tasks.Task;

namespace Project2.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var companies = _service.GetAllCompanies().ToList();
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
                _service.AddCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var company = _service.GetCompanyById(id);
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
                _service.UpdateCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public IActionResult Delete(int id)
        {
            var company = _service.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteCompany(id);
            return RedirectToAction("Index");
        }
      
    }
}
