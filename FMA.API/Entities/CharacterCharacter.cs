using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Entities
{
    [Table("FamilyMembers")]
    public class CharacterCharacter
    {
        public Guid Id2 { get; set; }
        public Character FamilyMember2 { get; set; }
        public Guid Id { get; set; }
        public Character FamilyMember { get; set; }

    }
}
