﻿using Core.Entities;
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
    public interface IMedBillRepository
    {
        void Create(MedicineBill medicineBill);

        void Update(MedicineBill medicineBill);

        void Delete(Guid id);

        Task<MedicineBill> GetById(Guid id);

        List<MedicineBill> GetType();
    }
}