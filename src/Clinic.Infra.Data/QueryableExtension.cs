using System;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infra.Data
{
    public static class QueryableExtension
    {
        public static async Task<PagedResult<T>> RecoverPagedAsync<T>(
            this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalSize = query.Count()
            };

            var pageCount = (double) result.TotalSize / pageSize;
            result.PageCount = (int) Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Data = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}