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
        Task<Doctor> GetById(Guid id);
        Task<Doctor> Create(Doctor doctor);
        Task Update(Doctor doctor);
        Task Delete(Guid id);
        Task<IEnumerable<Doctor>> Search(string name);
        List<Doctor> GetType();
    }
}
