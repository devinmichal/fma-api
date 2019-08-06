using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMA.API.Entities
{
    public class Character
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Aliases { get; set; }
        public Guid NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }
      //  public ICollection<CharacterCharacter> FamilyMembers { get; set; } = new List<CharacterCharacter>();
        public Guid OccupationId { get; set; }
        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }
        public string Abilities { get; set; }
        public string Weapon { get; set; }
        public string Rank { get; set; }
        public string Goal { get; set; }
        public Guid CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
