using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Models
{
    public class CountryToUpdateDto
    {
        public string Name { get; set; }
        public Guid CapitalId { get; set; }
        public Guid CurrencyId { get; set; }
        public int Founded { get; set; }
        public int Population { get; set; }
        public string Government { get; set; }
        public Guid GovernorId { get; set; }
        public Guid NationalityId { get; set; }
    }
}
