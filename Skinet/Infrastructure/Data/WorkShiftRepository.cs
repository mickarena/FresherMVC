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
    public class WorkShiftRepository : IWorkShiftRepository
    {
        private readonly StoreContext _context;
        public WorkShiftRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<WorkShift> GetById(Guid id)
        {
            return await _context.WorkShifts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WorkShift> Create(WorkShift workShift)
        {
            await _context.WorkShifts.AddAsync(workShift);
            await _context.SaveChangesAsync();
            return workShift;
        }

        public async Task Edit(WorkShift workShift)
        {
            _context.Entry(workShift).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var deleteWorkShift = await _context.WorkShifts.FindAsync(id);
            _context.WorkShifts.Remove(deleteWorkShift);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetWorkShift()
        {
            return await _context.WorkShifts.ToListAsync();
        }
    }
}