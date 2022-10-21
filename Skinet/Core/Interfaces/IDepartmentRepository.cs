﻿using Core.Entities;
namespace Core.Interfaces
{
    public interface IDepartmentRepository
    {
        void Create(Department departments);
        void Update(Department departments);
        void Delete(Guid id);
        List<Department> GetAll(string? searchString);
        Department GetbyId(Guid id);
    }
}