using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface INurseRepository
    {
        void Create(Nurse nurse);

        void Update(Nurse nurse);

        void Delete(Guid id);
        IEnumerable<Nurse> GetAll();
        Nurse GetbyId(Guid id);
    }
}
