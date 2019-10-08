using System.ComponentModel.DataAnnotations;


namespace FMA.API.Models
{
    public class CapitalToCreateDto
    {
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
