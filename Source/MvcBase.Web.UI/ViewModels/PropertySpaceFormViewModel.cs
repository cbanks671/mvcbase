using MvcBase.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBase.Web.ViewModels
{
    public class PropertySpaceFormViewModel
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Suite { get; set; }
        public int Floor { get; set; }
        [Display(Name = "Total Space Available")]
        public int TotalSpaceAvailable { get; set; }
        [Display(Name = "Minimum Divisible(sqft)")]
        public int MinDivisible { get; set; }
        [Display(Name = "Maximum Contiguous(sqft)")]
        public int MaxContiguous { get; set; }
        [Display(Name = "Building Space")]
        public int BuildingSize { get; set; }
        [Display(Name = "Year Built")]
        public int YearBuilt { get; set; }
        [Display(Name = "Date Available")]
        public DateTime DateAvailable { get; set; }
        [Display(Name = "Lease Rate")]
        public decimal LeaseRate { get; set; }
        [Display(Name = "Lease Rate Factor")]
        public PropertyRateFactor LeaseRateFactor { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Price Factor")]
        public PropertyPriceFactor PriceFactor { get; set; }
        [Display(Name = "Hide Price")]
        public bool HidePrice { get; set; }
        public int PropertyId { get; set; }
    }
}