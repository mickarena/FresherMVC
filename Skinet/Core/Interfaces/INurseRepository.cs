﻿using Core.Entities;
namespace Core.Interfaces
{
    public interface INurseRepository
    {
        void Create(Nurse nurse);

        void Update(Nurse nurse);

        void Delete(Guid id);
        List<Nurse> GetAll();
        Nurse GetbyId(Guid id);
    }
}
