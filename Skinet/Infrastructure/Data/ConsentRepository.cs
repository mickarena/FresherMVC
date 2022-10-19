using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Infrastructure.Data
{
    public class ConsentRepository : IConsentRepository
    {
        private readonly StoreContext _context;

        public ConsentRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Consent> Details(Guid id)
        {
            return await _context.Consents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Consent> Insert(Consent consent)
        {
            await _context.Consents.AddAsync(consent);
            await _context.SaveChangesAsync();
            return consent;
        }

        public async Task<IEnumerable<Consent>> List()
        {
            return await _context.Consents.ToListAsync();
        }

        public async Task<Consent> Update(Consent consent)
        {
            _context.Consents.Update(consent);
            await _context.SaveChangesAsync();
            return consent;
        }
    }
}
