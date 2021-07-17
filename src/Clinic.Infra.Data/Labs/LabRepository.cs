using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Domain.Common;
using Clinic.Domain.Labs;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infra.Data.Labs
{
    public class LabRepository : Repository<Lab, int>, ILabRepository
    {
        public LabRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Lab>> Get(IEnumerable<int> ids) =>
            await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<PagedResult<Lab>> Filter(
            int page,
            int pageSize,
            long id,
            string name,
            Status status)
        {
            var exams = DbSet.AsQueryable();

            if (id != 0)
                exams = exams.Where(x => x.Id == id);
            if (!string.IsNullOrWhiteSpace(name))
                exams = exams.Where(x => x.Name.Contains(name));
            if (status != Status.None)
                exams = exams.Where(x => x.Status == status);

            return await exams.RecoverPagedAsync(page, pageSize);
        }
    }
}