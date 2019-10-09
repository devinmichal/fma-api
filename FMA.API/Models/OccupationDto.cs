using FMA.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMA.API.Models
{
    public class OccupationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //not sure if information is needed
       // public IEnumerable<Character>  Members { get; set; }
    }
}
