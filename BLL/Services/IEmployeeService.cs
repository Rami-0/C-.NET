using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Company> GetCompaniesByEmployeeId(int employeeId);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}

