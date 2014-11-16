using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class PropertySpaceFeature
    {
        [Key]
        public int Id { get; set; }
        public PropertySpace PropertySpace { get; set; }
        public Feature Feature { get; set; }
    }
}
