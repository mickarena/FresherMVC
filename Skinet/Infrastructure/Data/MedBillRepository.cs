using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedBillRepository : IMedBillRepository
    {
        private StoreContext _context;

        public MedBillRepository()
        {
            _context = new StoreContext();
        }

        public void Create(MedicineBill medicineBill)
        {
            _context.MedicineBills.Add(medicineBill);
            _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var temp = _context.MedicineBills.FirstOrDefault(c => c.Id == id);
            _context.MedicineBills.Remove(temp);
            _context.SaveChangesAsync();
        }

        public async Task<MedicineBill> GetById(Guid id)
        {
            return await _context.MedicineBills.FindAsync(id);
        }

        public void Update(MedicineBill medicineBill)
        {
            _context.MedicineBills.Update(medicineBill);
            _context.SaveChangesAsync();
        }

        public IEnumerable<MedicineBill> GetType()
        {
            return _context.MedicineBills.ToList();
        }
    }
}