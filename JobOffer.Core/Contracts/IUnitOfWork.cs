

namespace JobOffer.Core.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IGenericRepository<TEntity, TKey> GetReposoitory<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}

