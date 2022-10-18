using Core.Entities;
using Core.Interfaces;

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

        public List<Department> GetAll()
        {
            return _db.Departments.ToList();
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
