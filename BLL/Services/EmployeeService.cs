using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public IEnumerable<Company> GetCompaniesByEmployeeId(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);

            if (employee == null)
            {
                throw new InvalidOperationException("Сотрудник не найден");
            }

            // Получите компании, связанные с этим сотрудником
            var companies = employee.Companies;

            return companies;
        }


        public IEnumerable<Employee> GetAllEmployees() => _employeeRepository.GetAll();

        public Employee GetEmployeeById(int id) => _employeeRepository.GetById(id);

        public void AddEmployee(Employee employee) => _employeeRepository.Add(employee);

        public void UpdateEmployee(Employee employee) => _employeeRepository.Update(employee);

        public void DeleteEmployee(int id) => _employeeRepository.Delete(id);
    }
}
