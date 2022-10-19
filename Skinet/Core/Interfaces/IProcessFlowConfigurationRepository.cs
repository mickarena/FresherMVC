using Core.Entities;
namespace Core.Interfaces
{
    public interface IProcessFlowConfigurationRepository
    {
        Task<IEnumerable<ProcessFlowConfiguration>> List();
    }
}
