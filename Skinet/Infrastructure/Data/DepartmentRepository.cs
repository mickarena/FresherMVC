using Core.Entities;
using Core.Interfaces;
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
        public DepartmentRepository(StoreContext context)
        {
            _db = context;
        }

        public void Create(Department departments)
        {
            _db.Departments.Add(departments);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Department departments = _db.Departments.Find(id);
            _db.Departments.Remove(departments);
            _db.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _db.Department.ToList();
        }

        public Department GetbyId(Guid id)
        {
            var departments = _db.Departments.Find(id);
            return departments;
        }

        public void Update(Department departments)
        {
            _db.Departments.Update(departments);
            _db.SaveChanges();
        }
    }
}
