using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBase.Web.ViewModels
{
    public class UserProfileFormModel
    {
        public UserProfileFormModel()
        {
            DateEdited = DateTime.Now;
        }

        public string Id { get; set; }

        public DateTime DateEdited { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public double? ContactNo { get; set; }

        public int CompanyId { get; set; }
    }
}