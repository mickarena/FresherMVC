using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedTypeRepository : IMedicineTypeRepository
    {
        private StoreContext _context;

        public MedTypeRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task Create(MedicineType medicineType)
        {
            _context.MedicineTypes.Add(medicineType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var temp = _context.MedicineTypes.FirstOrDefault(c => c.Id == id);
            _context.MedicineTypes.Remove(temp);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineType> GetById(Guid id)
        {
            return await _context.MedicineTypes.FindAsync(id);
        }

        public async Task Update(MedicineType medicineType)
        {
            _context.MedicineTypes.Update(medicineType);
            await _context.SaveChangesAsync();
        }

        public List<MedicineType> GetType(string search)
        {
            var list = _context.MedicineTypes.ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                list = list.Where(c => c.Name.Contains(search)).ToList();
            }
            return list;
        }
    }
}