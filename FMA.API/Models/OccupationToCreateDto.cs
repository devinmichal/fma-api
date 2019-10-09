﻿using System.ComponentModel.DataAnnotations;

namespace FMA.API.Models
{
    public class OccupationToCreateDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Desciption { get; set; }
    }
}
