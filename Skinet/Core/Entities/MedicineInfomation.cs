

namespace Core.Entities
{
    public class MedicineInfomation : BaseEntity
    {
        public Guid IdType { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public bool IsEmpty { get; set; }

        public MedicineType? MedicineType { get; set; }
        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}