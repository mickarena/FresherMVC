using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    internal class MedicineTypeRepository
    {
        private StoreContext _context;

        public MedicineTypeRepository()
        {
            _context = new StoreContext();
        }

        public void Create(MedicineType medicineType)
        {
            _context.MedicineTypes.Add(medicineType);
            _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var temp = _context!.MedicineTypes.FirstOrDefault(c => c.Id == id);
            _context.MedicineTypes.Remove(temp!);
            _context.SaveChangesAsync();
        }

        public async Task<MedicineType> GetById(Guid id)
        {
            return await _context.MedicineTypes.FindAsync(id);
        }

        public void Update(MedicineType medicineType)
        {
            _context.MedicineTypes.Update(medicineType);
            _context.SaveChangesAsync();
        }

        public List<MedicineType> GetType()
        {
            return _context!.MedicineTypes.ToList();
        }
    }
}