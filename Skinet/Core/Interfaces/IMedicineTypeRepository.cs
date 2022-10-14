using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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