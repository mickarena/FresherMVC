using System;
using System.Collections.Generic;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IShiftRepository
    {
        Task<Shift> GetById(Guid id);
        Task<Shift> Create(Shift shift);
        Task Update(Shift shift);
        Task Delete(Guid id);
        Task<IEnumerable<Shift>> GetShift();
        Task<IEnumerable<Shift>> Search(string name);
        List<Shift> GetType();
    }
}