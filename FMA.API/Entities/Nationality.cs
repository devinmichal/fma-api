using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FMA.API.Entities
{
    public class Nationality
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public Country Country { get; set; }
        public ICollection<Character> Members { get; set; } = new List<Character>();
    }
}
