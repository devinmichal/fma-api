using System.ComponentModel.DataAnnotations;

namespace FMA.API.Models
{
    public class CharacterToCreateDto
    {
        [MaxLength(100)]
        public string firstName { get; set; }

        [MaxLength(100)]
        public string lastName { get; set; }

        [MaxLength(3)]
        public string Age { get; set; }

        [MaxLength(100)]
        public string Aliases { get; set; }


        [MaxLength(500)]
        public string Abilities { get; set; }

        [MaxLength(500)]
        public string Weapon { get; set; }

        [MaxLength(100)]
        public string Rank { get; set; }

        [MaxLength(500)]
        public string Goal { get; set; }
    }
}
