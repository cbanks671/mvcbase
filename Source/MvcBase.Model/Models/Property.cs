using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class Property
    {
        public Property()
        {
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
        public int TotalSpaceAvailable { get; set; }
        public decimal RentalRate { get; set; }
        public int MinDivisible { get; set; }
        public int MaxContiguous { get; set; }
        public int BuildingSize { get; set; }
        public int YearBuilt { get; set; }
        public int ListingId { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual Company Company { get; set; }
        public PropertyType PropertyType { get; set; }
        public PropertySubType PropertySubType { get; set; }
        public BuildingClass BuildingClass { get; set; }
    }
}
