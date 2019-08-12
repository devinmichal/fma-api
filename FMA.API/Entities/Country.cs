using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Capital Capital { get; set; }
        public Guid? CapitalId { get; set; }
        public Currency Currency { get; set; }
        public Guid? CurrencyId { get; set; }
        public int Founded { get; set; }
        public int Population { get; set; }
        public string Government { get; set; }
        [ForeignKey("GovernorId")]
        public Character Governor { get; set; }
        public Guid? GovernorId { get; set; }
        public Nationality Nationality { get; set; }
        public Guid? NationalityId { get; set; }
    }
}
