using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;
using System.Collections.Generic;

namespace MvcBase.Service
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompany(int id);
        void CreateCompany(Company company);
        void UpdateCompany(Company company);
        void SaveCompany();
    }
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Company> GetCompanies()
        {
            var company = companyRepository.GetAll();
            return company;
        }

        public Company GetCompany(int id)
        {
            var company = companyRepository.Get(c => c.Id == id);
            return company;
        }

        public void CreateCompany(Company company)
        {
            companyRepository.Add(company);
            SaveCompany();
        }
        public void UpdateCompany(Company company)
        {
            companyRepository.Update(company);
            SaveCompany();
        }
        public void SaveCompany()
        {
            unitOfWork.Commit();
        }
    }
}
