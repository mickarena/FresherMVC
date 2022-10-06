using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class WorkShiftRepository : IWorkShiftRepository
    {
        private StoreContext _context;

        public WorkShiftRepository()
        {
            _context = new StoreContext();
        }

        public void Create(WorkShift workShift)
        {
            _context.WorkShifts.Add(workShift);
            _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var temp = _context!.WorkShifts.FirstOrDefault(c => c.IdWork == id);
            _context.WorkShifts.Remove(temp!);
            _context.SaveChangesAsync();
        }

        public async Task<WorkShift> GetById(Guid id)
        {
            return await _context.WorkShifts.FindAsync(id);
        }

        public void Update(WorkShift workShift)
        {
            _context.WorkShifts.Update(workShift);
            _context.SaveChangesAsync();
        }

        public List<WorkShift> GetType()
        {
            return _context.WorkShifts.ToList();
        }
    }
}