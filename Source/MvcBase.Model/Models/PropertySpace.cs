using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBase.Model.Models
{
    public class PropertySpace
    {
        public PropertySpace()
        {
            DateCreated = DateTime.Now;
            DateEdited = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string Suite { get; set; }
        public int Floor { get; set; }
        public int TotalSpaceAvailable { get; set; }
        public int MinDivisible { get; set; }
        public int MaxContiguous { get; set; }
        public int BuildingSize { get; set; }
        public int YearBuilt { get; set; }
        public DateTime DateAvailable { get; set; }
        public decimal LeaseRate { get; set; }
        public PropertyRateFactor LeaseRateFactor { get; set; }
        public decimal Price { get; set; }
        public PropertyPriceFactor PriceFactor { get; set; }
        public bool HidePrice { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}
