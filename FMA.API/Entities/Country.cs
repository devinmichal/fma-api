using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FMA.API.Entities
{
    public class Country
    {
        [Required]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public Capital Capital { get; set; }

        [Required]
        public Guid? CapitalId { get; set; }
        public Currency Currency { get; set; }

        [Required]
        public Guid? CurrencyId { get; set; }

        [MaxLength(4)]
        public int Founded { get; set; }

        [MaxLength(100)]
        public int Population { get; set; }
        [MaxLength(100)]

        public string Government { get; set; }
     
        public Nationality Nationality { get; set; }

        [Required]
        public Guid? NationalityId { get; set; }

        public IEnumerable<Character> Members { get; set; } = new List<Character>();
    }
}
