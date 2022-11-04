using Microsoft.Build.Framework;

namespace MVCADO.Models
{
    public class Film
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public DateTime Release { get; set; }

        [Required]

        public string Real { get; set; }
    }
}
