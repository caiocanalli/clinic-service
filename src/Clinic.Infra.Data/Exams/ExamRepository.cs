using System.Linq;
using System.Threading.Tasks;
using Clinic.Domain.Common;
using Clinic.Domain.Exams;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infra.Data.Exams
{
    public class ExamRepository : Repository<Exam, long>, IExamRepository
    {
        public ExamRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Exam> GetByIdWithLabs(long id) =>
            await DbSet.Include(x => x.Labs)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<PagedResult<Exam>> Filter(
            int page,
            int pageSize,
            long id,
            string name,
            ExamType type,
            Status status)
        {
            var exams = DbSet.AsQueryable();

            if (id != 0)
                exams = exams.Where(x => x.Id == id);
            if (!string.IsNullOrWhiteSpace(name))
                exams = exams.Where(x => x.Name.Contains(name));
            if (type != ExamType.None)
                exams = exams.Where(x => x.Type == type);
            if (status != Status.None)
                exams = exams.Where(x => x.Status == status);

            exams = exams.Include(x => x.Labs);

            return await exams.RecoverPagedAsync(page, pageSize);
        }
    }
}