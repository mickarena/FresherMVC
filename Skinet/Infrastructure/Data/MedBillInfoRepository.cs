<<<<<<< HEAD
﻿//using Core.Entities;
//using Core.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
=======
﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//namespace Infrastructure.Data
//{
//    public class MedBillInfoRepository : IMedBillInfoRepository
//    {
//        private StoreContext _context;

<<<<<<< HEAD
//        public MedBillInfoRepository()
//        {
//            _context = new StoreContext();
//        }
=======
        public MedBillInfoRepository(StoreContext context)
        {
            _context = context;
        }
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//        public void Create(MedicineBillInfo medicineBillInfo)
//        {
//            _context.MedicineBillInfos.Add(medicineBillInfo);
//            _context.SaveChangesAsync();
//        }

//        public void Delete(Guid id)
//        {
//            var temp = _context!.MedicineBillInfos.FirstOrDefault(c => c.Id == id);
//            _context.MedicineBillInfos.Remove(temp!);
//            _context.SaveChangesAsync();
//        }

<<<<<<< HEAD
//        public async Task<MedicineBillInfo> GetById(Guid id)
//        {
//            return await _context.MedicineBillInfos.FindAsync(id);
//        }
=======
        public async Task<MedicineBillInfo> GetById(Guid id)
        {
            return _context.MedicineBillInfos.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//        public void Update(MedicineBillInfo medicineBillInfo)
//        {
//            _context.MedicineBillInfos.Update(medicineBillInfo);
//            _context.SaveChangesAsync();
//        }

<<<<<<< HEAD
//        public List<MedicineBillInfo> GetType()
//        {
//            return _context.MedicineBillInfos.ToList();
//        }
//    }
//}
=======
        public List<MedicineBillInfo> GetType()
        {
            return _context.MedicineBillInfos.Include(m => m.MedicineBills).Include(c => c.MedicineInfomations).AsNoTracking().ToList();
        }
    }
}
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f
