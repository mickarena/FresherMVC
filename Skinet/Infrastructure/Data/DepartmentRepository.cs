using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public List<Department> GetAll(string? searchString)
        {

            var list = _db.Departments.ToList();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                list = list.Where(c => c.Name.Contains(searchString)).ToList();
            }
            return list;
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
