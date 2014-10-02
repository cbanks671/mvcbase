using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBase.Model.Models
{
    public class BuildingClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
