using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBase.Web.ViewModels
{
    public class PropertyListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public double? ZipCode { get; set; }
        public DateTime DateCreated { get; set; }
    }
}