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
    public interface IMedBillInfoRepository
    {
        void Create(MedicineBillInfo medicineBillInfo);

        void Update(MedicineBillInfo medicineBillInfo);

        void Delete(Guid id);

        Task<MedicineBillInfo> GetById(Guid id);

        List<MedicineBillInfo> GetType();
    }
}