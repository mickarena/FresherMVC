using System;
using System.Collections.Generic;
using Core.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IShiftRepository
    {
        Task<Shift> GetById(Guid id);
        Task<Shift> Create(Shift shift);
        Task Edit(Shift shift);
        Task Delete(Guid id);
        Task<IEnumerable<Shift>> GetShift();
        List<Shift> GetType();
        Task<IEnumerable<Shift>> Search(string searchString);
    }
}