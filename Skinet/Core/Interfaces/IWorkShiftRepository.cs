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
        void Create(WorkShift workShift);

        void Update(WorkShift workShift);

        void Delete(Guid id);

        Task<WorkShift> GetById(Guid id);

        List<WorkShift> GetType();
    }
}