using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Clinic.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Clinic.Infra.Data
{
    public abstract class Repository<TAggregateRoot, TKey> :
        IRepository<TAggregateRoot, TKey> where TAggregateRoot : AggregateRoot<TKey>
    {
        protected readonly DbSet<TAggregateRoot> DbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            DbSet = ((UnitOfWork) unitOfWork).Context.Set<TAggregateRoot>();
        }

        public async Task Add(TAggregateRoot entity) =>
            await DbSet.AddAsync(entity);

        public async Task<TAggregateRoot> GetById(TKey id) =>
            await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<PagedResult<TAggregateRoot>> Get(
            int page,
            int pageSize,
            Expression<Func<TAggregateRoot, bool>> predicate = null,
            Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null,
            Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null)
        {
            var query = DbSet.AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (include != null)
                query = include(query);

            return await query.RecoverPagedAsync(page, pageSize);
        }

        public async Task Update(TAggregateRoot entity) =>
            await Task.Run(() => DbSet.Update(entity));

        public async Task Delete(TAggregateRoot entity) =>
            await Task.Run(() => DbSet.Remove(entity));
    }
}