using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Entities
{
    public class Affiliation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CharacterAffiliation> KnownMembers { get; set; } = new List<CharacterAffiliation>();
    }
}
