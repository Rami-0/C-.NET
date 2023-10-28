using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _repository;

        public CompanyService(IGenericRepository<Company> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Company> GetAllCompanies() => _repository.GetAll();

        public Company GetCompanyById(int id) => _repository.GetById(id);

        public void AddCompany(Company company) => _repository.Add(company);

        public void UpdateCompany(Company company) => _repository.Update(company);

        public void DeleteCompany(int id) => _repository.Delete(id);
    }
}
