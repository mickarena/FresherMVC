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
        Task<MedicineBillInfo> Create(MedicineBillInfo medicineBillInfo);

        Task<MedicineBillInfo> Update(MedicineBillInfo medicineBillInfo);

        Task<MedicineBillInfo> Delete(Guid id);

        Task<MedicineBillInfo> GetById(Guid id);

        Task<MedicineBillInfo> GetType();
    }
}