using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMedicineInfoRepository
    {
        void Create(MedicineInfomation medicineInfomation);

        void Update(MedicineInfomation medicineInfomation);

        void Delete(Guid id);

        Task<MedicineInfomation> GetById(Guid id);

        List<MedicineInfomation> GetType();
    }
}