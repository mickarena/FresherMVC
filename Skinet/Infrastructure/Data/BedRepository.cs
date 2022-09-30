using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BedRepository : IBadRepository
    {
        private readonly StoreContext _context;
        public BedRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<HospitalBed> Create(HospitalBed request)
        {
            var HospitalBed = new HospitalBed()
            {
                Status = request.Status,
                IdPatient = request.IdPatient,
                IdRoom=request.IdRoom,
            };
            _context.HospitalBed.Add(HospitalBed);
            await _context.SaveChangesAsync();  
            throw new NotImplementedException();
        }

        public async Task<HospitalBed> Delete(int Id)
        {
            var HospitalBed = await _context.HospitalBed.FindAsync(Id);
            _context.HospitalBed.Remove(HospitalBed);
            throw new NotImplementedException();
        }

        public async Task<HospitalBed> Update(HospitalBed request)
        {
            var HospitalBed = await _context.HospitalBed.FindAsync(request.Id);
            var BedTranslation = _context.HospitalBed.FirstOrDefault(x=>x.Id==request.Id);
            BedTranslation.Status = request.Status;
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
