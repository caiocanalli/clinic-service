using System.Threading.Tasks;
using Clinic.Application.Common;
using Clinic.Application.Labs.Requests;
using Clinic.Application.Labs.Responses;

namespace Clinic.Application.Labs
{
    public interface ILabAppService
    {
        Task<Result> Register(RegisterRequest request);
        Task<Result<RecoverByIdResponse>> RecoverById(int id);
        Task<Result<FilterResponse>> Filter(FilterRequest request);
        Task<Result> Activate(int id);
        Task<Result> Inactivate(int id);
        Task<Result> Update(UpdateRequest request);
    }
}