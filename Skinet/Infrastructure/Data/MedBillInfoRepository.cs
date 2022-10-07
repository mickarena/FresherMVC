using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    internal class MedBillInfoRepository : IMedBillRepository
    {
        public Task<MedicineBill> Create(MedicineBill medicineBill)
        {
            throw new NotImplementedException();
        }

        public Task<MedicineBill> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicineBill> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicineBill> Update(MedicineBill medicineBill)
        {
            throw new NotImplementedException();
        }

        Task<MedicineBill> IMedBillRepository.GetType()
        {
            throw new NotImplementedException();
        }
    }
}