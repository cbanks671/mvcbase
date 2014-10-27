using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBase.Web.ViewModels
{
    public class PropertyFormViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public double? ZipCode { get; set; }
        public int TotalSpaceAvailable { get; set; }
        public decimal RentalRate { get; set; }
        public int MinDivisible { get; set; }
        public int MaxContiguous { get; set; }
        public int BuildingSize { get; set; }
        public int YearBuilt { get; set; }
        public int ListingId { get; set; }
        public int CompanyId { get; set; }
        //public PropertyTypeFormModel PropertyType { get; set; }
        //public PropertySubType PropertySubType { get; set; }
        //public BuildingClass BuildingClass { get; set; }
    }

    //public class PropertyTypeFormModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}