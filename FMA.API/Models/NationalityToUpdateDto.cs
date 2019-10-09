using System.ComponentModel.DataAnnotations;

namespace FMA.API.Models
{
    public class NationalityToUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
 
    }
}
