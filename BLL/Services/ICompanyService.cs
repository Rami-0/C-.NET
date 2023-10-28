using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);
    }
}
