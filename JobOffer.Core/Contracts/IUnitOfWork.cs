
namespace JobOffer.Core.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IGenericRepository<TEntity, TKey> GetReposoitory<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}

