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
//    public class MedTypeRepository : IMedicineTypeRepository
//    {
//        private StoreContext _context;

<<<<<<< HEAD
//        public MedTypeRepository()
//        {
//            _context = new StoreContext();
//        }
=======
        public MedTypeRepository(StoreContext context)
        {
            _context = context;
        }
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//        public void Create(MedicineType medicineType)
//        {
//            _context.MedicineTypes.Add(medicineType);
//            _context.SaveChangesAsync();
//        }

//        public void Delete(Guid id)
//        {
//            var temp = _context!.MedicineTypes.FirstOrDefault(c => c.Id == id);
//            _context.MedicineTypes.Remove(temp!);
//            _context.SaveChangesAsync();
//        }

//        public async Task<MedicineType> GetById(Guid id)
//        {
//            return await _context.MedicineTypes.FindAsync(id);
//        }

//        public void Update(MedicineType medicineType)
//        {
//            _context.MedicineTypes.Update(medicineType);
//            _context.SaveChangesAsync();
//        }

<<<<<<< HEAD
//        public List<MedicineType> GetType()
//        {
//            return _context.MedicineTypes.ToList();
//        }
//    }
//}
=======
        public List<MedicineType> GetType()
        {
            return _context.MedicineTypes.AsNoTracking().ToList();
        }
    }
}
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f
