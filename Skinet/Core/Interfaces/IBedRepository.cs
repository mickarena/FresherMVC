using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBedRepository : IGenericRepository<HospitalBed>
    {
        Task<HospitalBed> Create(HospitalBed request);

        Task<HospitalBed> Update(HospitalBed request);

        Task<HospitalBed> Delete(Guid Id);
        Task<HospitalBed> GetById(Guid Id);
        Task<IEnumerable<HospitalBed>> Search(string name);
    }
}