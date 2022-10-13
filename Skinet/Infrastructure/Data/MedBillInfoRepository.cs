using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedBillInfoRepository : IMedBillInfoRepository
    {
        private StoreContext _context;

        public MedBillInfoRepository(StoreContext context)
        {
            _context = context;
        }

        public void Create(MedicineBillInfo medicineBillInfo)
        {
            _context.MedicineBillInfos.Add(medicineBillInfo);
            _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var temp = _context!.MedicineBillInfos.FirstOrDefault(c => c.Id == id);
            _context.MedicineBillInfos.Remove(temp!);
            _context.SaveChangesAsync();
        }

        public async Task<MedicineBillInfo> GetById(Guid id)
        {
            return _context.MedicineBillInfos.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void Update(MedicineBillInfo medicineBillInfo)
        {
            _context.MedicineBillInfos.Update(medicineBillInfo);
            _context.SaveChangesAsync();
        }

        public List<MedicineBillInfo> GetType()
        {
            return _context.MedicineBillInfos.Include(m => m.MedicineBills).Include(c => c.MedicineInfomations).AsNoTracking().ToList();
        }
    }
}