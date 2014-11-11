using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class Property
    {
        public Property()
        {
            DateCreated = DateTime.Now;
            DateEdited = DateTime.Now;
        }
        [Key]
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
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual PropertyListType PropertyListType { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual PropertySubType PropertySubType { get; set; }
    }
}
