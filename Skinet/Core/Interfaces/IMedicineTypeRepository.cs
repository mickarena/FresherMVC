using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedicineTypeRepository
    {
        Task Create(MedicineType medicineType);

        Task Update(MedicineType medicineType);

        Task DeleteAsync(Guid id);

        Task<MedicineType> GetById(Guid id);

        List<MedicineType> GetType(string search);
    }
}