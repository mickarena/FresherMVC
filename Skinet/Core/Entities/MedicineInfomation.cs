using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineInfomation : BaseEntity
    {
        [Required]
        public Guid MedicineIDType { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime ImportDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public bool IsEmpty { get; set; }

        public MedicineType? MedicineTypes { get; set; }
        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}