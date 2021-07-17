using System.Threading.Tasks;
using Clinic.Domain.Common;

namespace Clinic.Domain.Exams
{
    public interface IExamRepository : IRepository<Exam, long>
    {
        Task<Exam> GetByIdWithLabs(long id);

        Task<PagedResult<Exam>> Filter(
            int page,
            int pageSize,
            long id,
            string name,
            ExamType type,
            Status status);
    }
}