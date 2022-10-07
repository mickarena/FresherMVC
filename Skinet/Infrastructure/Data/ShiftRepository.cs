using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly StoreContext _context;
        public ShiftRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<Shift> Create(Shift shift)
        {
            await _context.Shifts.AddAsync(shift);
            await _context.SaveChangesAsync();
            return shift;
        }

        public async Task Update(Shift shift)
        {
            _context.Entry(shift).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var deleteShift = await _context.Shifts.FindAsync(id);
            _context.Shifts.Remove(deleteShift);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Shift>> GetShift()
        {
            return await _context.Shifts.ToListAsync();
        }

        public async Task<Shift> GetById(Guid id)
        {
            return await _context.Shifts.FirstOrDefaultAsync(x => x.IdShift == id);
        }

        public async Task<IEnumerable<Shift>> Search(string name)
        {
            IQueryable<Shift> query = _context.Shifts;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.ShiftName.Contains(name));
            }
            return await query.ToListAsync();
        }
    }
}