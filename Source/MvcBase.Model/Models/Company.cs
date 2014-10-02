using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBase.Model.Models
{
    public class Company
    {
        public Company()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public double? ZipCode { get; set; }
        public double? ContactNo { get; set; }
    }
}
