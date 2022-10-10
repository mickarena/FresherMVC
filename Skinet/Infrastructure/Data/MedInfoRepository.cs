using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedInfoRepository : IMedicineInfoRepository
    {
        private StoreContext _context;

        public MedInfoRepository()
        {
            _context = new StoreContext();
        }

        public void Create(MedicineInfomation medicineInfomation)
        {
            _context.MedicineInfomations.Add(medicineInfomation);
            _context.SaveChangesAsync();
        }

        public async void Delete(Guid id)
        {
            var temp = _context.MedicineInfomations.FirstOrDefault(c => c.Id == id);
            _context.MedicineInfomations.Remove(temp);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineInfomation> GetById(Guid id)
        {
            return await _context.MedicineInfomations.FindAsync(id);
        }

        public async void Update(MedicineInfomation medicineInfomation)
        {
            var data = _context.MedicineInfomations.Update(medicineInfomation);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<MedicineInfomation> GetType()
        {
            return _context.MedicineInfomations.Include(m => m.MedicineTypes).ToList();
        }
    }
}