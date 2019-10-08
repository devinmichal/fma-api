using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FMA.API.Entities
{
    public class Capital
    {
        [Required]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        public Country Country { get; set; }
    }
}
