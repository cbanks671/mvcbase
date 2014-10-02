using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class SubscriptionPlan
    {
        [Key]
        public int Id { get; set; }
        public string FriendlyId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public SubscriptionInterval Interval { get; set; }
        public int TrialPeriodInDays { get; set; }
        public bool Disabled { get; set; }
        //public virtual StripeAccount StripeAccount { get; set; }
    }
}
