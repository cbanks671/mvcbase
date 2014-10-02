using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? Start { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? End { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? TrialStart { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? TrialEnd { get; set; }
        public int SubscriptionPlanId { get; set; }
        public virtual SubscriptionPlan SubscriptionPlan { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        //public string StripeId { get; set; }
        //public virtual StripeAccount StripeAccount { get; set; }

    }
}
