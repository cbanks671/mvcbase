using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;

namespace MvcBase.Service
{
    public interface ISubscriptionPlanService
    {
        SubscriptionPlan GetSubscriptionPlan(int id);

        void CreateSubscriptionPlan(SubscriptionPlan subscriptionPlan);
        void UpdateSubscriptionPlan(SubscriptionPlan subscriptionPlan);
        void SaveSubscriptionPlan();
    }
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly ISubscriptionPlanRepository subscriptionPlanRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubscriptionPlanService(ISubscriptionPlanRepository subscriptionPlanRepository, IUnitOfWork unitOfWork)
        {
            this.subscriptionPlanRepository = subscriptionPlanRepository;
            this.unitOfWork = unitOfWork;
        }

        public SubscriptionPlan GetSubscriptionPlan(int id)
        {
            var subscriptionPlan = subscriptionPlanRepository.Get(c => c.Id == id);
            return subscriptionPlan;
        }

        public void CreateSubscriptionPlan(SubscriptionPlan subscriptionPlan)
        {
            subscriptionPlanRepository.Add(subscriptionPlan);
            SaveSubscriptionPlan();
        }
        public void UpdateSubscriptionPlan(SubscriptionPlan subscriptionPlan)
        {
            subscriptionPlanRepository.Update(subscriptionPlan);
            SaveSubscriptionPlan();
        }
        public void SaveSubscriptionPlan()
        {
            unitOfWork.Commit();
        }
    }
}
