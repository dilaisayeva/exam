using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Models
{
    public class Sagird
    {
        [Key]
        public int SagirdNomresi { get; set; }

        [Required]
        [StringLength(30)]
        public string? Adi { get; set; }  // Nullable string

        [Required]
        [StringLength(30)]
        public string? Soyadi { get; set; }  // Nullable string

        [Required]
        public int Sinifi { get; set; }
    }
}
