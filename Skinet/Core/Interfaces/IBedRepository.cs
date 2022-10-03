using Core.Entities;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBedRepository: IGenericRepository<HospitalBed>
    {
        Task<HospitalBed> Create(HospitalBed request);
        Task<HospitalBed> Update(HospitalBed request);
        Task<HospitalBed> Delete(int Id);

    }
}
