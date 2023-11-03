using DAL.DatabaseContext;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly AppDbContext _context;
        public CompanyService(
            IGenericRepository<Company> companyRepository,
            IGenericRepository<Employee> employeeRepository,
            AppDbContext context)

        {
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
            _context = context;
        }
        public IEnumerable<Employee> GetEmployeesByCompanyId(int companyId)
        {
            // Находим компанию по ID
            var company = _companyRepository.GetById(companyId);

            if (company == null)
            {
                throw new InvalidOperationException("Компания не найдена");
            }

            // Находим сотрудников, принадлежащих данной компании
            var employeesInCompany = _employeeRepository.GetAll().Where(e => e.CompanyId == companyId);

            return employeesInCompany;
        }
        public IEnumerable<Company> GetAllCompanies() => _companyRepository.GetAll();

        public Company GetCompanyById(int id) => _companyRepository.GetById(id);

        public void AddCompany(Company company) => _companyRepository.Add(company);

        public void UpdateCompany(Company company) => _companyRepository.Update(company);

        public void DeleteCompany(int id) => _companyRepository.Delete(id);
        public void AddEmployeeToCompany(int companyId, int employeeId)
        {
            // Получите компанию по companyId
            var company = _context.Companies.Find(companyId);

            if (company == null)
            {
                throw new InvalidOperationException("Компания не найдена");
            }

            // Получите сотрудника по employeeId
            var employee = _context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new InvalidOperationException("Сотрудник не найден");
            }

            // Добавьте сотрудника к компании
            company.Employees.Add(employee);

            // Сохраните изменения в базе данных
            _context.SaveChanges();
        }

        public void RemoveEmployeeFromCompany(int companyId, int employeeId)
        {
            var company = _context.Companies.Find(companyId);

            if (company == null)
            {
                throw new InvalidOperationException("Компания не найдена");
            }

            var employee = _context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new InvalidOperationException("Сотрудник не найден");
            }

            company.Employees.Remove(employee);

            _context.SaveChanges();
        }
    }
  

}
