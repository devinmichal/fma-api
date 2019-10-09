using System.ComponentModel.DataAnnotations;

namespace FMA.API.Models
{
    public class NationalityToCreateDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
