using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;
using System.Collections.Generic;

namespace MvcBase.Service
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetProperties(int companyId);
        Property GetProperty(int id);
        void CreateProperty(Property property);
        void UpdateProperty(Property property);
        void SaveProperty();
    }
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository propertyRepository;
        private readonly IUnitOfWork unitOfWork;

        public PropertyService(IPropertyRepository propertyRepository, IUnitOfWork unitOfWork)
        {
            this.propertyRepository = propertyRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Property> GetProperties(int companyId)
        {
            var property = propertyRepository.GetMany(p => p.Company.Id == companyId);
            return property;
        }

        public Property GetProperty(int id)
        {
            var property = propertyRepository.Get(c => c.Id == id);
            return property;
        }

        public void CreateProperty(Property property)
        {
            propertyRepository.Add(property);
            SaveProperty();
        }
        public void UpdateProperty(Property property)
        {
            propertyRepository.Update(property);
            SaveProperty();
        }
        public void SaveProperty()
        {
            unitOfWork.Commit();
        }
    }
}
