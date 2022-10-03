using Core.Entities;
using Core.Interfaces;
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

        public async Task<HospitalBed> Delete(int Id)
        {
            var HospitalBeds = await _context.HospitalBeds.FindAsync(Id);
            _context.HospitalBeds.Remove(HospitalBeds);
            return HospitalBeds;
        }

        public async Task<HospitalBed> Update(HospitalBed request)
        {
            var BedTranslation = _context.HospitalBeds.FirstOrDefault(x => x.Id == request.Id);
            BedTranslation.Status = request.Status;
            BedTranslation.IDPatient = request.IDPatient;
            BedTranslation.IDRoom = request.IDRoom;
            await _context.SaveChangesAsync();
            return BedTranslation;
        }
    }
}
