using Core.Entities;


namespace Core.Interfaces
{
    public interface INurseRepository
    {
        void Create(Nurse nurse);

        void Update(Nurse nurse);

        void Delete(Guid id);   

        IEnumerable<Nurse> GetAll();

        Nurse GetbyId(Guid id);
    }
}
