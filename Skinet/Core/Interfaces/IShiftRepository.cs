using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IShiftRepository
    {
        Task<Shift> Create(Shift request);

        Task<Shift> Update(Shift request);

        Task<Shift> Delete(Guid IdShift);
        Task<Shift> GetById(Guid IdShift);
    }
}