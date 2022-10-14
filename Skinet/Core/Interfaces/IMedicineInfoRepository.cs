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
    public interface IMedicineInfoRepository
    {
        void Create(MedicineInfomation medicineInfomation);

        void Update(MedicineInfomation medicineInfomation);

        void Delete(Guid id);

        Task<MedicineInfomation> GetById(Guid id);

        List<MedicineInfomation> GetType();
    }
}