using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Pagination<HospitalBed>> Search(string name, int pageIndex, int pageSize)
        {
            IQueryable<HospitalBed> query = _context.HospitalBeds;
                       if (!string.IsNullOrEmpty(name))
                       {
                           query = query.Where(e => e.IDRoom.Contains(name) || e.IDPatient.Contains(name));
                       }
            var result = new Pagination<HospitalBed>
            {
                Items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(),
                TotalItems = query.Count(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPage = query.Count() / pageSize,
                startPage = pageIndex - 5,
                endPage = pageIndex + 4,
        };
            return result;

        }
        public async Task<HospitalBed> Update(HospitalBed request)
        {
            _context.HospitalBeds.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }
        Task IBedRepository.Search(string searchName, int pageIndex)
        {
            throw new NotImplementedException();
        }
    }
}