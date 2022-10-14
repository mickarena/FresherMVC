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
        void Create(Departments departments);

        void Update(Departments departments);

        void Delete(Guid id);

        IEnumerable<Departments> GetAll();

        Departments GetbyId(Guid id);
    }
}
