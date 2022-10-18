using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedBillInfoRepository
    {
        void Create(MedicineBillInfo medicineBillInfo);

        void Update(MedicineBillInfo medicineBillInfo);

        void Delete(Guid id);

        Task<MedicineBillInfo> GetById(Guid id);

        List<MedicineBillInfo> GetType(Guid search);
    }
}