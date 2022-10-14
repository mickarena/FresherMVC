<<<<<<< HEAD
﻿//using Core.Entities;
//using Core.Interfaces;
//using Microsoft.EntityFrameworkCore;
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
//    public class DoctorRepository : IDoctorRepository
//    {
//        private readonly StoreContext _context;
//        public DoctorRepository(StoreContext context)
//        {
//            _context = context;
//        }
//        public async Task<Doctor> Create(Doctor doctor)
//        {
//            await _context.Doctors.AddAsync(doctor);
//            await _context.SaveChangesAsync();
//            return doctor;
//        }

//        public async Task Delete(Guid id)
//        {
//            var doctorToDelete = await _context.Doctors.FindAsync(id);
//            _context.Doctors.Remove(doctorToDelete);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<IEnumerable<Doctor>> GetDoctor()
//        {
//            return await _context.Doctors.ToListAsync();
//        }

//        public async Task<Doctor> GetById(Guid id)
//        {
//            return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);

//        }

<<<<<<< HEAD
//        public async Task Update(Doctor doctor)
//        {
//            _context.Entry(doctor).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//        }
=======
        public async Task Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();           
        }
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f

//        public async Task<IEnumerable<Doctor>> Search(string name)
//        {
//            IQueryable<Doctor> query = _context.Doctors;
//            if (!string.IsNullOrEmpty(name))
//            {
//                query = query.Where(e => e.Name.Contains(name) || e.Department.Contains(name) || e.Address.Contains(name));
//            }
//            return await query.ToListAsync();
//        }
//    }
//}
