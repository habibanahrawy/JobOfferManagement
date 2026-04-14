using JobOffer.Core.Contracts;


namespace JobOffer.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        private readonly Dictionary<Type, object> _repositories = [];

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IGenericRepository<TEntity, TKey> GetReposoitory<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {

            var EtityType = typeof(TEntity);

            if (_repositories.TryGetValue(EtityType, out object? repository))
            {
                return (IGenericRepository<TEntity, TKey>)repository;
            }

            var newrepo = new GenericReposoitory<TEntity, TKey>(_dbContext);
            _repositories[EtityType] = newrepo;
            return newrepo;

        }
        

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
