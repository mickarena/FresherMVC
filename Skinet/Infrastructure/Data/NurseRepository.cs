using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class NurseRepository : INurseRepository
    {
        readonly StoreContext _db;
        public NurseRepository(StoreContext context)
        { 
            _db = context;
        }

        public void Create(Nurse nurse)
        {
            _db.Nurse.Add(nurse);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Nurse nurse = _db.Nurse.Find(id);
            _db.Nurse.Remove(nurse);
            _db.SaveChanges();
        }

        public IEnumerable<Nurse> GetAll()
        {
            return _db.Nurse.Include(x => x.Departments).ToList();
        }

        public Nurse GetbyId(Guid id)
        {
            var nurse = _db.Nurse.Find(id);
            return nurse;
        }

        public void Update(Nurse nurse)
        {
            _db.Nurse.Update(nurse);
            _db.SaveChanges();
        }
    }
}
