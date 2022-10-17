using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDepartmentRepository
    {
        void Create(Department departments);
        void Update(Department departments);
        void Delete(Guid id);
        IEnumerable<Department> GetAll();
        Department GetbyId(Guid id);
    }
}
