using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;
using System.Collections.Generic;

namespace MvcBase.Service
{
    public interface IPropertySpaceService
    {
        IEnumerable<PropertySpace> GetPropertySpaces(int propertyId);
        PropertySpace GetPropertySpace(int id);
        void CreatePropertySpace(PropertySpace property);
        void UpdatePropertySpace(PropertySpace property);
        void SavePropertySpace();
    }
    public class PropertySpaceService : IPropertySpaceService
    {
        private readonly IPropertySpaceRepository propertySpaceRepository;
        private readonly IUnitOfWork unitOfWork;

        public PropertySpaceService(IPropertySpaceRepository propertySpaceRepository, IUnitOfWork unitOfWork)
        {
            this.propertySpaceRepository = propertySpaceRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PropertySpace> GetPropertySpaces(int propertyId)
        {
            var propertySpace = propertySpaceRepository.GetMany(p => p.Property.Id == propertyId);
            return propertySpace;
        }

        public PropertySpace GetPropertySpace(int id)
        {
            var propertySpace = propertySpaceRepository.Get(c => c.Id == id);
            return propertySpace;
        }

        public void CreatePropertySpace(PropertySpace propertySpace)
        {
            propertySpaceRepository.Add(propertySpace);
            SavePropertySpace();
        }
        public void UpdatePropertySpace(PropertySpace propertySpace)
        {
            propertySpaceRepository.Update(propertySpace);
            SavePropertySpace();
        }
        public void SavePropertySpace()
        {
            unitOfWork.Commit();
        }
    }
}
