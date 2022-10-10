using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedicineInfoRepository
    {
        void Create(MedicineInfomation medicineInfomation);

        void Update(MedicineInfomation medicineInfomation);

        void Delete(Guid id);

        Task<MedicineInfomation> GetById(Guid id);

        IEnumerable<MedicineInfomation> GetType();
    }
}