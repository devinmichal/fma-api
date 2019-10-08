using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMA.API.Entities
{
    public class Character
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(3)]
        public int Age { get; set; }

        [MaxLength(100)]
        public string Aliases { get; set; }

        [Required]
        public Guid? NationalityId { get; set; }

        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }

        [Required]
        public Guid? OccupationId { get; set; }

        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }

        [MaxLength(500)]
        public string Abilities { get; set; }

        [MaxLength(500)]
        public string Weapon { get; set; }


        //Will change this to a lookup table in Database
        [MaxLength(100)]
        public string Rank { get; set; }

        [MaxLength(500)]
        public string Goal { get; set; }

        [Required]
        public Guid? CountryId { get; set; }
        
        public Country Country { get; set; }
    }
}
