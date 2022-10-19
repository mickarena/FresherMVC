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

        public async Task Create(MedicineBillInfo medicineBillInfo)
        {
            _context.MedicineBillInfos.Add(medicineBillInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var temp = _context.MedicineBillInfos.FirstOrDefault(c => c.Id == id);
            _context.MedicineBillInfos.Remove(temp);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineBillInfo> GetById(Guid id)
        {
            return _context.MedicineBillInfos.FirstOrDefault(c => c.Id == id);
        }

        public async Task Update(MedicineBillInfo medicineBillInfo)
        {
            _context.MedicineBillInfos.Update(medicineBillInfo);
            await _context.SaveChangesAsync();
        }

        public List<MedicineBillInfo> GetType(Guid search)
        {
            var list = _context.MedicineBillInfos.Include(m => m.MedicineBills).Include(c => c.MedicineInfomations).ToList();
            if (search != Guid.Empty)
            {
                list = list.Where(c => c.MedicineBillID == search).ToList();
            }
            return list;
        }
    }
}