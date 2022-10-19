﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedInfoRepository : IMedicineInfoRepository
    {
        private StoreContext _context;

        public MedInfoRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task Create(MedicineInfomation medicineInfomation)
        {
            _context.MedicineInfomations.Add(medicineInfomation);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var temp = _context.MedicineInfomations.FirstOrDefault(c => c.Id == id);
            _context.MedicineInfomations.Remove(temp!);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicineInfomation> GetById(Guid id)
        {
            return _context.MedicineInfomations.Include(c => c.MedicineTypes).FirstOrDefault(c => c.Id == id);
        }

        public async Task Update(MedicineInfomation medicineInfomation)
        {
            var data = _context.MedicineInfomations.Update(medicineInfomation);
            await _context.SaveChangesAsync();
        }

        public List<MedicineInfomation> GetType(string search)
        {
            var list = _context.MedicineInfomations.Include(m => m.MedicineTypes).ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                list = list.Where(c => c.Name.StartsWith(search)).ToList();
            }
            return list;
        }
    }
}