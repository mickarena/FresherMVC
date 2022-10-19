using Core.Entities;

namespace Core.Interfaces
{
    public interface IConsentRepository
    {
        Task<IEnumerable<Consent>> List();
        Task<Consent> Details(Guid id);
        Task<Consent> Insert(Consent consent);
        Task<Consent> Update(Consent consent);
    }
}
