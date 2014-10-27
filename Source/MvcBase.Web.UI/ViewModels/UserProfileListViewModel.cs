using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBase.Web.ViewModels
{
    public class UserProfileListViewModel
    {
        public string Id { get; set; }
        
        public string Email { get; set; }
  
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateCreated { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [DataType(DataType.PhoneNumber)]
        public double? ContactNo { get; set; }

        public string UserName{get;set;}

    }
}