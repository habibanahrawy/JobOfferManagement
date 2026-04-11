using System;
using System.Collections.Generic;
using System.Text;
using JobOffer.Application.Contracts;

namespace JobOffer.Core.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IGenericRepository<TEntity, TKey> GetReposoitory<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}

