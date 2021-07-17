using System.Collections.Generic;
using System.Threading.Tasks;
using Clinic.Domain.Common;

namespace Clinic.Domain.Labs
{
    public interface ILabRepository : IRepository<Lab, int>
    {
        Task<List<Lab>> Get(IEnumerable<int> ids);

        Task<PagedResult<Lab>> Filter(
            int page,
            int pageSize,
            long id,
            string name,
            Status status);
    }
}