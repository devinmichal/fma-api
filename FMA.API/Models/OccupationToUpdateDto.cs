
using System.ComponentModel.DataAnnotations;


namespace FMA.API.Models
{
    public class OccupationToUpdateDto : OccupationManipulationDto
    { 
        [Required]
        [MaxLength(1000)]
        public string Decsription { get; set; }
    }
}
