using System.ComponentModel.DataAnnotations;
namespace FMA.API.Models
{
    public abstract class OccupationManipulationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public virtual string Desciption { get; set; }
    }
}
