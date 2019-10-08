using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Models
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Nationality { get; set; }
        public string Currency { get; set; }
        public int Popuation { get; set; }
        public int Founded { get; set; }
        public string Government { get; set; }
    }
}
