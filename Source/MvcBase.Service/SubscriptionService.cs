using MvcBase.Data.Repository;
using MvcBase.Data.Infrastructure;
using MvcBase.Model.Models;
using System;

namespace MvcBase.Service
{
    public interface ISubscriptionService
    {
        Subscription GetSubscription(int id);

        void CreateSubscription(Subscription subscription);
        void UpdateSubscription(Subscription subscription);
        void SaveSubscription();
    }
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository subscriptionRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            this.subscriptionRepository = subscriptionRepository;
            this.unitOfWork = unitOfWork;
        }

        public Subscription GetSubscription(int id)
        {
            var subscription = subscriptionRepository.Get(c => c.Id == id);
            return subscription;
        }

        public void CreateSubscription(Subscription subscription)
        {
            subscriptionRepository.Add(subscription);
            SaveSubscription();
        }
        public void UpdateSubscription(Subscription subscription)
        {
            subscriptionRepository.Update(subscription);
            SaveSubscription();
        }
        public void SaveSubscription()
        {
            unitOfWork.Commit();
        }
    }
}
