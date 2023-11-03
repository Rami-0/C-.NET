using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        IEnumerable<Employee> GetEmployeesByCompanyId(int companyId);

        void RemoveEmployeeFromCompany(int companyId, int employeeId);
        void AddEmployeeToCompany(int companyId, int employeeId);
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);
    }

}
