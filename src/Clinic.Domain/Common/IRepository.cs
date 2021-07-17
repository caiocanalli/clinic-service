using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Clinic.Domain.Common
{
    public interface IRepository<TAggregateRoot, in TKey> where TAggregateRoot : AggregateRoot<TKey>
    {
        Task Add(TAggregateRoot entity);
        Task<TAggregateRoot> GetById(TKey id);
        Task<PagedResult<TAggregateRoot>> Get(
            int page,
            int pageSize,
            Expression<Func<TAggregateRoot, bool>> predicate = null,
            Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null,
            Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null);
        Task Update(TAggregateRoot entity);
        Task Delete(TAggregateRoot entity);
    }
}