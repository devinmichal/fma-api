using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Models
{
    public class CharacterToUpdateDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Age { get; set; }
        public string Aliases { get; set; }
        public string Abilities { get; set; }
        public string Weapon { get; set; }
        public string Rank { get; set; }
        public string Goal { get; set; }
        public Guid CountryId { get; set; }
        public Guid NationalityId { get; set; }
        public Guid OccupationId { get; set; }
    }
}
