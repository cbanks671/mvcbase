using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class PropertySubType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }
    }
}
