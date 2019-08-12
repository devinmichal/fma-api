using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Models
{
    public class CountryToCreateDto
    {
        public string Name { get; set; }
        
        public int Founded { get; set; }
        public int Population { get; set; }
        public string Government { get; set; }
     
    }
}
