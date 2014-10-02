using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class PropertyFeature
    {
        [Key]
        public int Id { get; set; }
        public Property Property { get; set; }
        public Feature Feature { get; set; }
    }
}
