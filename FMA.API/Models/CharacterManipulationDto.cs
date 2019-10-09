using System.ComponentModel.DataAnnotations;
using System;

namespace FMA.API.Models
{
    public class CharacterManipulationDto
    {
        [Required]
        [MaxLength(100)]
        public string firstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string lastName { get; set; }

        [Required]
        [MaxLength(3)]
        public string Age { get; set; }


        
        [MaxLength(100)]
        public string Aliases { get; set; }

        [MaxLength(500)]
        public string Abilities { get; set; }


        
        [MaxLength(500)]
        public string Weapon { get; set; }

        
        [MaxLength(100)]
        public string Rank { get; set; }

        [MaxLength(500)]
        public string Goal { get; set; }

        public Guid CountryId { get; set; }
        public Guid NationalityId { get; set; }
        public Guid OccupationId { get; set; }
    }
}
