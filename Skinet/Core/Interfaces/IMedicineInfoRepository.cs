using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedicineInfoRepository
    {
        Task Create(MedicineInfomation medicineInfomation);

        Task Update(MedicineInfomation medicineInfomation);

        Task Delete(Guid id);

        Task<MedicineInfomation> GetById(Guid id);

        List<MedicineInfomation> GetType(string search);
    }
}