using System.Collections.ObjectModel;
using CarWashManager.DataAccess.Entities;

namespace CarWashManager.DataAccess.RepositoriesWash.Wash
{
    public interface IWashRepository
    {
        Task<ReadOnlyCollection<WashEntity>> Get();
        Task<WashEntity?> Get(string WashId);
        Task<ReadOnlyCollection<WashEntity>> Get(Func<WashEntity, bool> predicate);
        Task Create(WashEntity entity);
        Task Update(WashEntity entity);
        Task Delete(string WashId);
    }
}
