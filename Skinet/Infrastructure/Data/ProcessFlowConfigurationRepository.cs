using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProcessFlowConfigurationRepository : IProcessFlowConfigurationRepository
    {

        private readonly StoreContext _context;

        public ProcessFlowConfigurationRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProcessFlowConfiguration>> List()
        {
            return await _context.processFlowConfigurations.ToListAsync();
        }
    }
}
