<<<<<<< HEAD
﻿//using Core.Entity;
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
//    public class MedInfoRepository : IMedicineInfoRepository
//    {
//        private StoreContext _context;

<<<<<<< HEAD
//        public MedInfoRepository()
//        {
//            _context = new StoreContext();
//        }
=======
        public MedInfoRepository(StoreContext context)
        {
            _context = context;
        }
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//        public void Create(MedicineInfomation medicineInfomation)
//        {
//            _context.MedicineInfomations.Add(medicineInfomation);
//            _context.SaveChangesAsync();
//        }

<<<<<<< HEAD
//        public void Delete(Guid id)
//        {
//            var temp = _context!.MedicineInfomations.FirstOrDefault(c => c.Id == id);
//            _context.MedicineInfomations.Remove(temp!);
//            _context.SaveChangesAsync();
//        }

//        public async Task<MedicineInfomation> GetById(Guid id)
//        {
//            return await _context.MedicineInfomations.FindAsync(id);
//        }

//        public void Update(MedicineInfomation medicineInfomation)
//        {
//            _context.MedicineInfomations.Update(medicineInfomation);
//            _context.SaveChangesAsync();
//        }

//        public List<MedicineInfomation> GetType()
//        {
//            return _context.MedicineInfomations.ToList();
//        }
//    }
//}
=======
        public async void Delete(Guid id)
        {
            var temp = _context!.MedicineInfomations.FirstOrDefault(c => c.Id == id);
            _context.MedicineInfomations.Remove(temp!);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineInfomation> GetById(Guid id)
        {
            return _context.MedicineInfomations.Include(c => c.MedicineTypes).AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public async void Update(MedicineInfomation medicineInfomation)
        {
            var data = _context.MedicineInfomations.Update(medicineInfomation);
            await _context.SaveChangesAsync();
        }

        public List<MedicineInfomation> GetType()
        {
            return _context.MedicineInfomations.Include(m => m.MedicineTypes).AsNoTracking().ToList();
        }
    }
}
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f
