
namespace JobOffer.Infrastructure.Repositories
{
    public class GenericReposoitory<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly AppDbContext _dbContext;

        public GenericReposoitory(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task DeleteAsync(TKey id)
        {
            var Entity =await _dbContext.Set<TEntity>().FindAsync(id);
            if(Entity != null)
            {
                _dbContext.Set<TEntity>().Remove(Entity);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) => await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
   


        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)=> await _dbContext.Set<TEntity>().FindAsync(id ,cancellationToken );


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
