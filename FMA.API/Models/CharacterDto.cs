using FMA.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Models
{
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Aliases { get; set; }
        public string Nationality { get; set; }
        public string Age { get; set; }
        public string Abilities { get; set; }
        public string Weapon { get; set; }
        public string Rank { get; set; }
        public string Goal { get; set; }
        public string Occupation { get; set; }
        public string Country { get; set; }
        
    }
}
