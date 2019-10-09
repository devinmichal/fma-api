using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Models
{
    public class NationalityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }

        // probably not needed will need to consider 
        
      //  public IEnumerable<CharacterDto> Members { get; set; }
    }
}
