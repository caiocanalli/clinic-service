using System.Threading.Tasks;
using Clinic.Application.Common;
using Clinic.Application.Exams.Requests;
using Clinic.Application.Exams.Responses;

namespace Clinic.Application.Exams
{
    public interface IExamAppService
    {
        Task<Result> Register(RegisterRequest request);
        Task<Result<RecoverByIdResponse>> RecoverById(int id);
        Task<Result<FilterResponse>> Filter(FilterRequest request);
        Task<Result> Activate(int id);
        Task<Result> Inactivate(int id);
        Task<Result> Update(UpdateRequest request);
    }
}