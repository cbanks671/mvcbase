using MvcBase.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBase.Web.ViewModels
{
    public class PropertyFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter a property name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a property address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter a zip code")]
        public double? ZipCode { get; set; }
        public PropertyListType PropertyListType { get; set; }
        [Display(Name = "Property Type")]
        public virtual int PropertyTypeId { get; set; }
        public virtual PropertySubType PropertySubType { get; set; }
        public int CompanyId { get; set; }

        public IEnumerable<SelectListItem> PropertyTypeList { get; set; }
        //public IEnumerable<SelectListItem> PropertySubTypeList { get; set; }
    }

    public class PropertyTypeFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PropertySubTypeFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}