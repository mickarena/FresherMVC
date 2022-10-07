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
    public class DepartmentRepository : IDepartmentRepository
    {
        readonly StoreContext _db;
        public DepartmentRepository(StoreContext _db)
        {
            _db = _db;
        }

        public void Create(Departments departments)
        {
            _db.Departments.Add(departments);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Departments departments = _db.Departments.Find(id);
            _db.Departments.Remove(departments);
            _db.SaveChanges();
        }

        public IEnumerable<Departments> GetAll()
        {
            return _db.Departments;
        }

        public Departments GetbyId(Guid id)
        {
            var departments = _db.Departments.Find(id);
            return departments;
        }

        public void Update(Departments departments)
        {
            _db.Entry(departments).State = EntityState.Modified;
        }
    }
}
