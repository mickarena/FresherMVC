using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IWorkShiftRepository
    {
        Task<WorkShift> GetById(Guid id);
        Task<WorkShift> Create(WorkShift workShift);
        Task Edit(WorkShift workShift);
        Task Delete(Guid id);
        Task<IEnumerable<WorkShift>> GetWorkShift();
    }
}