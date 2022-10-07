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
        Task<MedicineType> Creat(MedicineType medicineType);

        Task<MedicineType> Update(MedicineType medicineType);

        Task Delete(Guid id);

        Task<MedicineType> GetById(Guid id);

        Task<MedicineType> GetType();
    }
}