using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedBillInfoRepository
    {
        Task Create(MedicineBillInfo medicineBillInfo);

        Task Update(MedicineBillInfo medicineBillInfo);

        Task Delete(Guid id);

        Task<MedicineBillInfo> GetById(Guid id);

        List<MedicineBillInfo> GetType(Guid search);
    }
}