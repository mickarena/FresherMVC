using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IWorkShiftRepository
    {
        Task<WorkShift> Create(WorkShift request);

        Task<WorkShift> Update(WorkShift request);

        Task<WorkShift> Delete(Guid IdWork);
        Task<WorkShift> GetById(Guid IdWork);
    }
}