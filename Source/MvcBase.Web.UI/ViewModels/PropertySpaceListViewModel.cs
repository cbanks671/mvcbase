using MvcBase.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBase.Web.ViewModels
{
    public class PropertySpaceListViewModel
    {
        public int Id { get; set; }
        public string Suite { get; set; }
        public int Floor { get; set; }
        [Display(Name = "Total Space Available")]
        public int TotalSpaceAvailable { get; set; }
        [Display(Name = "Year Built")]
        public int YearBuilt { get; set; }
        [Display(Name = "Date Available")]
        public DateTime DateAvailable { get; set; }
    }
}