using Core.Entities;

namespace Core.Interfaces
{
    public interface IWorkShiftRepository
    {
        Task<WorkShift> GetById(Guid id);
        Task<WorkShift> Create(WorkShift workShift);
        Task Edit(WorkShift workShift);
        Task Delete(Guid id);
        Task<IEnumerable<WorkShift>> GetWorkShift();
    }
}