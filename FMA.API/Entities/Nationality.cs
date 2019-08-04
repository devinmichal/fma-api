using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Entities
{
    public class Nationality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public ICollection<Character> Members { get; set; } = new List<Character>();
    }
}
