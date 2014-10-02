using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;

namespace MvcBase.Service
{
    public interface IPropertyTypeService
    {
        PropertyType GetPropertyType(int id);

        void CreatePropertyType(PropertyType propertyType);
        void UpdatePropertyType(PropertyType propertyType);
        void SavePropertyType();
    }
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IPropertyTypeRepository propertyTypeRepository;
        private readonly IUnitOfWork unitOfWork;

        public PropertyTypeService(IPropertyTypeRepository propertyTypeRepository, IUnitOfWork unitOfWork)
        {
            this.propertyTypeRepository = propertyTypeRepository;
            this.unitOfWork = unitOfWork;
        }

        public PropertyType GetPropertyType(int id)
        {
            var propertyType = propertyTypeRepository.Get(c => c.Id == id);
            return propertyType;
        }

        public void CreatePropertyType(PropertyType propertyType)
        {
            propertyTypeRepository.Add(propertyType);
            SavePropertyType();
        }
        public void UpdatePropertyType(PropertyType propertyType)
        {
            propertyTypeRepository.Update(propertyType);
            SavePropertyType();
        }
        public void SavePropertyType()
        {
            unitOfWork.Commit();
        }
    }
}
