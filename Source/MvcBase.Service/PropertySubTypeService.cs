using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;

namespace MvcBase.Service
{
    public interface IPropertySubTypeService
    {
        PropertySubType GetPropertySubType(int id);

        void CreatePropertySubType(PropertySubType propertySubType);
        void UpdatePropertySubType(PropertySubType propertySubType);
        void SavePropertySubType();
    }
    public class PropertySubTypeService : IPropertySubTypeService
    {
        private readonly IPropertySubTypeRepository propertySubTypeRepository;
        private readonly IUnitOfWork unitOfWork;

        public PropertySubTypeService(IPropertySubTypeRepository propertySubTypeRepository, IUnitOfWork unitOfWork)
        {
            this.propertySubTypeRepository = propertySubTypeRepository;
            this.unitOfWork = unitOfWork;
        }

        public PropertySubType GetPropertySubType(int id)
        {
            var propertySubType = propertySubTypeRepository.Get(c => c.Id == id);
            return propertySubType;
        }

        public void CreatePropertySubType(PropertySubType propertySubType)
        {
            propertySubTypeRepository.Add(propertySubType);
            SavePropertySubType();
        }
        public void UpdatePropertySubType(PropertySubType propertySubType)
        {
            propertySubTypeRepository.Update(propertySubType);
            SavePropertySubType();
        }
        public void SavePropertySubType()
        {
            unitOfWork.Commit();
        }
    }
}
