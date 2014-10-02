using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
