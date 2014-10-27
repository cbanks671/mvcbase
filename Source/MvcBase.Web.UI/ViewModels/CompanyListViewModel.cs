using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBase.Web.ViewModels
{
    public class CompanyListViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public double? ContactNo { get; set; }
    }
}