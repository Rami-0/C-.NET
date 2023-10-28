using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;

        public EmployeeService(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAllEmployees() => _repository.GetAll();

        public Employee GetEmployeeById(int id) => _repository.GetById(id);

        public void AddEmployee(Employee employee) => _repository.Add(employee);

        public void UpdateEmployee(Employee employee) => _repository.Update(employee);

        public void DeleteEmployee(int id) => _repository.Delete(id);
    }
}
