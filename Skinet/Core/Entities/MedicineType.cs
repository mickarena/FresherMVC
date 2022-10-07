using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineType : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public IEnumerable<MedicineInfomation>? MedicineInfomations { get; set; }
    }
}