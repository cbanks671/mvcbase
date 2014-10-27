using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBase.Web.ViewModels
{
    public class CompanyFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Display(Name = "Postal Code")]
        public double? ZipCode { get; set; }
        public double? ContactNo { get; set; }
    }
}