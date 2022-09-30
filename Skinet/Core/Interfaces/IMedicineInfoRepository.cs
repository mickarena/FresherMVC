using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMedicineInfoRepository
    {
        Task<MedicineInfomation> Create(MedicineInfomation medicineInfomation);

        Task<MedicineInfomation> Update(MedicineInfomation medicineInfomation);

        Task<MedicineInfomation> Delete(Guid id);

        Task<MedicineInfomation> GetById(Guid id);

        Task<MedicineInfomation> GetType();
    }
}