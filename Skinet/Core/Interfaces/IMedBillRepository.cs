using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMedBillRepository
    {
        Task<MedicineBill> Create(MedicineBill medicineBill);

        Task<MedicineBill> Update(MedicineBill medicineBill);

        Task<MedicineBill> Delete(Guid id);

        Task<MedicineBill> GetById(Guid id);

        Task<MedicineBill> GetType();
    }
}