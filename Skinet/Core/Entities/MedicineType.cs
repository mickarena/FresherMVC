
namespace Core.Entities
{
    public class MedicineType : BaseEntity
    {
        public string? Name { get; set; }

        public IEnumerable<MedicineInfomation>? MedicineInfomations { get; set; }
    }
}