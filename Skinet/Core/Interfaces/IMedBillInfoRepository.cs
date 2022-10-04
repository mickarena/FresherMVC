using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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