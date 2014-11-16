using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;
using System.Collections.Generic;

namespace MvcBase.Service
{
    public interface IFeatureService
    {
        IEnumerable<Feature> GetFeatures();
        Feature GetFeature(int id);
        void CreateFeature(Feature feature);
        void UpdateFeature(Feature feature);
        void SaveFeature();
    }
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository featureRepository;
        private readonly IUnitOfWork unitOfWork;

        public FeatureService(IFeatureRepository featureRepository, IUnitOfWork unitOfWork)
        {
            this.featureRepository = featureRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Feature> GetFeatures()
        {
            var feature = featureRepository.GetAll();
            return feature;
        }

        public Feature GetFeature(int id)
        {
            var feature = featureRepository.Get(c => c.Id == id);
            return feature;
        }

        public void CreateFeature(Feature feature)
        {
            featureRepository.Add(feature);
            SaveFeature();
        }
        public void UpdateFeature(Feature feature)
        {
            featureRepository.Update(feature);
            SaveFeature();
        }
        public void SaveFeature()
        {
            unitOfWork.Commit();
        }
    }
}
