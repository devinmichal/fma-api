using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Entities
{
    public class CharacterAffiliation
    {
        public Guid MemberId { get; set; }
        public Character Member { get; set; }
    public Guid AffiliationId { get; set; }
    public Affiliation Affiliation { get; set; }
}
}
