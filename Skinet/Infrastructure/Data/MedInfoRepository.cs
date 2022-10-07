//using Core.Entity;
//using Core.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Data
//{
//    public class MedInfoRepository : IMedicineInfoRepository
//    {
//        private StoreContext _context;

//        public MedInfoRepository()
//        {
//            _context = new StoreContext();
//        }

//        public void Create(MedicineInfomation medicineInfomation)
//        {
//            _context.MedicineInfomations.Add(medicineInfomation);
//            _context.SaveChangesAsync();
//        }

//        public void Delete(Guid id)
//        {
//            var temp = _context!.MedicineInfomations.FirstOrDefault(c => c.Id == id);
//            _context.MedicineInfomations.Remove(temp!);
//            _context.SaveChangesAsync();
//        }

//        public async Task<MedicineInfomation> GetById(Guid id)
//        {
//            return await _context.MedicineInfomations.FindAsync(id);
//        }

//        public void Update(MedicineInfomation medicineInfomation)
//        {
//            _context.MedicineInfomations.Update(medicineInfomation);
//            _context.SaveChangesAsync();
//        }

//        public List<MedicineInfomation> GetType()
//        {
//            return _context.MedicineInfomations.ToList();
//        }
//    }
//}