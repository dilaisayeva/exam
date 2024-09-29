using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class Imtahan
    {
        [Key]
        public int ImtahanID { get; set; }

        [StringLength(3)]
        [ForeignKey(nameof(Ders))]
        public string? DersKodu { get; set; }  // Nullable string

        public int SagirdNomresi { get; set; }

        public DateTime ImtahanTarixi { get; set; }

        public int Qiymeti { get; set; }

        public virtual Ders? Ders { get; set; }  // Nullable navigation property

        public virtual Sagird? Sagird { get; set; }  
    }
}
