using System.ComponentModel.DataAnnotations;

namespace FMA.API.Models
{
    public class CountryToCreateDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(4)]
        public int Founded { get; set; }
        [MaxLength(100)]
        public int Population { get; set; }

        [MaxLength(100)]
        public string Government { get; set; }
     
    }
}
