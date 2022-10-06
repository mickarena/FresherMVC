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
        void Create(Shift shift);

        void Update(Shift shift);

        void Delete(Guid id);

        Task<Shift> GetById(Guid id);

        List<Shift> GetType();
    }
}