using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly StoreContext _context;
        public DoctorRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Create(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
    }
}
