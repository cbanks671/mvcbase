using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBase.Web.UI.Areas.Admin.ViewModel
{
    public class UserProfileListViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date created")]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.PhoneNumber)]
        public double? ContactNo { get; set; }
        public string UserName{get;set;}
        public int CompanyId { get; set; }
    }
}