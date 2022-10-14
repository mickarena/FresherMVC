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
//    public class MedBillRepository : IMedBillRepository
//    {
//        private StoreContext _context;

<<<<<<< HEAD
//        public MedBillRepository()
//        {
//            _context = new StoreContext();
//        }
=======
        public MedBillRepository(StoreContext context)
        {
            _context = context;
        }
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//        public void Create(MedicineBill medicineBill)
//        {
//            _context.MedicineBills.Add(medicineBill);
//            _context.SaveChangesAsync();
//        }

<<<<<<< HEAD
//        public void Delete(Guid id)
//        {
//            var temp = _context!.MedicineBills.FirstOrDefault(c => c.Id == id);
//            _context.MedicineBills.Remove(temp!);
//            _context.SaveChangesAsync();
//        }
=======
        public void Delete(Guid id)
        {
            var temp = _context!.MedicineBills.AsNoTracking().FirstOrDefault(c => c.Id == id);
            _context.MedicineBills.Remove(temp!);
            _context.SaveChangesAsync();
        }
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//        public async Task<MedicineBill> GetById(Guid id)
//        {
//            return await _context.MedicineBills.FindAsync(id);
//        }

//        public void Update(MedicineBill medicineBill)
//        {
//            _context.MedicineBills.Update(medicineBill);
//            _context.SaveChangesAsync();
//        }

<<<<<<< HEAD
//        public List<MedicineBill> GetType()
//        {
//            return _context.MedicineBills.ToList();
//        }
//    }
//}
=======
        public List<MedicineBill> GetType()
        {
            return _context.MedicineBills.AsNoTracking().ToList();
        }
    }
}
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f
