using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public enum SubscriptionInterval
    {
        Monthly,
        Yearly,
        Weekly,

        [Display(Name = "Every 6 months")]
        EverySixMonths,

        [Display(Name = "Every 3 months")]
        EveryThreeMonths
    }
}
