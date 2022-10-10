using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedicineTypeRepository
    {
        void Create(MedicineType medicineType);

        void Update(MedicineType medicineType);

        void Delete(Guid id);

        Task<MedicineType> GetById(Guid id);

        IEnumerable<MedicineType> GetType();
    }
}