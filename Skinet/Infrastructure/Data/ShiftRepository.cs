using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly StoreContext _context;
        public ShiftRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Shift> GetById(Guid id)
        {
            return await _context.Shifts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Shift> Create(Shift shift)
        {
            await _context.Shifts.AddAsync(shift);
            await _context.SaveChangesAsync();
            return shift;
        }

        public async Task Edit(Shift shift)
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

        public List<Shift> GetType()
        {
            return _context.Shifts.ToList();
        }

        public async Task<IEnumerable<Shift>> Search(string searchString)
        {
            IQueryable<Shift> query = _context.Shifts;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.ShiftName.Contains(searchString));
            }
            return await query.ToListAsync();
        }
    }
}