using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBase.Model.Models
{
    public enum PropertyListType
    {
        [Description("For Sale")]
        Sale = 1,
        [Description("For Lease")]
        Lease = 2
    }

    public enum PropertyTypeFilter
    {
        [Description("For Sale")]
        Sale = 1,
        [Description("For Lease")]
        Lease = 2,
        [Description("For Sale or Lease")]
        SaleLease = 3
    }

    public enum PropertyRateFactor
    {
        [Description("Rate/SF/Month")]
        SFPerMonth = 1,
        [Description("Rate/SF/Year")]
        SFPerYear = 2,
        [Description("Rate/Month")]
        RatePerMonth = 3,
        [Description("Rate/Year")]
        RatePerYear = 4
    }

    public enum PropertyPriceFactor
    {
        [Description("Price")]
        Price = 1,
        [Description("Price/SF")]
        PricePerSF = 2,
        [Description("Price/Acre")]
        PricePerAcre = 3
    }
}
