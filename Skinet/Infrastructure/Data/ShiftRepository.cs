using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ShiftRepository : IShiftRepository
    {
        private StoreContext _context;

        public ShiftRepository()
        {
            _context = new StoreContext();
        }

        public void Create(Shift shift)
        {
            _context.Shifts.Add(shift);
            _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var temp = _context!.Shifts.FirstOrDefault(c => c.IdShift == id);
            _context.Shifts.Remove(temp!);
            _context.SaveChangesAsync();
        }

        public async Task<Shift> GetById(Guid id)
        {
            return await _context.Shifts.FindAsync(id);
        }

        public void Update(Shift shift)
        {
            _context.Shifts.Update(shift);
            _context.SaveChangesAsync();
        }

        public List<Shift> GetType()
        {
            return _context.Shifts.ToList();
        }
    }
}