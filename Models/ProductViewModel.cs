using System;
using System.ComponentModel.DataAnnotations;

namespace Agri.Models
{
    public class ProductViewModel
    {
        [Required]
        public string? Name { get; set; } // Make nullable or provide a default value

        [Required]
        public string? Category { get; set; } // Make nullable or provide a default value

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
    }
}