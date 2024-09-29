using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Models
{
    public class Ders
    {
        [Key]
        [StringLength(3)]
        public string? DersKodu { get; set; }   
        [StringLength(30)]
        public string? DersAdi { get; set; }   

        [StringLength(20)]
        public string? MuellimAdi { get; set; } 

        [StringLength(20)]
        public string? MuellimSoyadi { get; set; }   
    }
}
