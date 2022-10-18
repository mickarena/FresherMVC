using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedBillRepository
    {
        void Create(MedicineBill medicineBill);

        void Update(MedicineBill medicineBill);

        void Delete(Guid id);

        Task<MedicineBill> GetById(Guid id);

        List<MedicineBill> GetType(Guid search);
    }
}