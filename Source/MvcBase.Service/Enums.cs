using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBase.Core.Common
{
    public enum PropertyTypeFilter
    {
        [Description("For Sale")]
        Sale = 0,
        [Description("For Lease")]
        Lease = 1,
        [Description("For Sale or Lease")]
        SaleLease = 2,
    }
}
