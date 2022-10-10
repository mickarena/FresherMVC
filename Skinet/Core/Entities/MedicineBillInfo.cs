using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineBillInfo : BaseEntity
    {
        [Required]
        public Guid MedicineBillID { get; set; }

        [Required]
        public Guid IdMedicineInfo { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        public MedicineInfomation? MedicineInfomations { get; set; }
        public MedicineBill? MedicineBills { get; set; }
    }
}