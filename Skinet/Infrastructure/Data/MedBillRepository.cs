using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedBillRepository : IMedBillRepository
    {
        private StoreContext _context;

        public MedBillRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task Create(MedicineBill medicineBill)
        {
            _context.MedicineBills.Add(medicineBill);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var temp = _context.MedicineBills.FirstOrDefault(c => c.Id == id);
            _context.MedicineBills.Remove(temp);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineBill> GetById(Guid id)
        {
            return await _context.MedicineBills.FindAsync(id);
        }

        public async Task Update(MedicineBill medicineBill)
        {
            _context.MedicineBills.Update(medicineBill);
            await _context.SaveChangesAsync();
        }

        public List<MedicineBill> GetType(Guid search)
        {
            var list = _context.MedicineBills.ToList();
            if (search != Guid.Empty)
            {
                list = list.Where(c => c.DoctorID == search).ToList();
            }
            return list;
        }
    }
}