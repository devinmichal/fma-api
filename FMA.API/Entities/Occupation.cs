using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FMA.API.Entities
{
    public class Occupation
    {
        [Required]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Decsription { get; set; }
        public ICollection<Character> Members { get; set; } = new List<Character>();
        
    }
}
