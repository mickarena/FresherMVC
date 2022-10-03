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
        void Create(MedicineBill medicineBill);

        void Update(MedicineBill medicineBill);

        void Delete(Guid id);

        Task<MedicineBill> GetById(Guid id);

        List<MedicineBill> GetType();
    }
}