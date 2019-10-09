using System.ComponentModel.DataAnnotations;
using System;

namespace FMA.API.Models
{
    public abstract class CountryManipulationDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

       
        [MaxLength(4)]
        public int Founded { get; set; }
        [MaxLength(100)]
        public int Population { get; set; }

        [MaxLength(100)]
        public string Government { get; set; }
        public Guid CapitalId { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid NationalityId { get; set; }
    }
}
