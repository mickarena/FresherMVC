using Core.Entities;

namespace Core.Interfaces
{
    public interface IMedBillRepository
    {
        Task Create(MedicineBill medicineBill);

        Task Update(MedicineBill medicineBill);

        Task Delete(Guid id);

        Task<MedicineBill> GetById(Guid id);

        List<MedicineBill> GetType(Guid search);
    }
}