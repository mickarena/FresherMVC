using Core.Entity;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    internal class MedBillInfoRepository : IMedBillInfoRepository
    {
        private StoreContext _context;

        public MedBillInfoRepository()
        {
            _context = new StoreContext();
        }

        public void Create(MedicineBillInfo medicineBillInfo)
        {
            _context.MedicineBillInfos.Add(medicineBillInfo);
            _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var temp = _context!.MedicineBillInfos.FirstOrDefault(c => c.Id == id);
            _context.MedicineBillInfos.Remove(temp!);
            _context.SaveChangesAsync();
        }

        public async Task<MedicineBillInfo> GetById(Guid id)
        {
            return await _context.MedicineBillInfos.FindAsync(id);
        }

        public void Update(MedicineBillInfo medicineBillInfo)
        {
            _context.MedicineBillInfos.Update(medicineBillInfo);
            _context.SaveChangesAsync();
        }

        public List<MedicineBillInfo> GetType()
        {
            return _context.MedicineBillInfos.ToList();
        }
    }
}