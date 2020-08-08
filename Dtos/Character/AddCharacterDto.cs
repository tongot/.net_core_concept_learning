using System.ComponentModel.DataAnnotations;
using learn_net_core.Models;

namespace learn_net_core.Dtos.Character
{
    public class AddCharacterDto
    {
        [Required]
        public string Name { get; set; } = "frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}