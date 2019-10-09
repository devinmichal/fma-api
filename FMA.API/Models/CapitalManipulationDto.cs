﻿using System.ComponentModel.DataAnnotations;

namespace FMA.API.Models
{
    public abstract class CapitalManipulationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
