using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedicineTypeRepository
    {
        void Create(MedicineType medicineType);

        void Update(MedicineType medicineType);

        void Delete(Guid id);

        dsfsfs

            dfsf

        Task<MedicineType> GetById(Guid id);

        List<MedicineType> GetType();
    }
}