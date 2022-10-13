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
    public class BedRepository : GenericRepository<HospitalBed>, IBedRepository
    {
        private readonly StoreContext _context;

        public BedRepository(StoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<HospitalBed> Create(HospitalBed request)
        {
            _context.HospitalBeds.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<HospitalBed> Delete(Guid Id)
        {
            var HospitalBeds = await _context.HospitalBeds.FindAsync(Id);
            _context.HospitalBeds.Remove(HospitalBeds);
            await _context.SaveChangesAsync();
            return HospitalBeds;
        }

        public async Task<HospitalBed> GetById(Guid Id)
        {
            return await _context.HospitalBeds.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<HospitalBed> Update(HospitalBed request)
        {

            _context.HospitalBeds.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
    }
}