using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctor();
        //Task<Doctor> GetById(int id);
        Task<Doctor> Create(Doctor doctor);
        Task Update(Doctor doctor);
        Task Delete(int id);
    }
}
