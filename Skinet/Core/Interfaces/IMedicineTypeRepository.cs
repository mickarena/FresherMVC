using Core.Entities;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

namespace Core.Interfaces
{
    public interface IMedicineTypeRepository
    {
        void Create(MedicineType medicineType);

        void Update(MedicineType medicineType);

        void Delete(Guid id);

        Task<MedicineType> GetById(Guid id);

        List<MedicineType> GetType();
    }
}