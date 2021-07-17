using AutoMapper;
using Clinic.Application.Labs.Responses;
using Clinic.Domain.Common;
using Clinic.Domain.Labs;

namespace Clinic.Application.Labs
{
    public class LabMapper : Profile
    {
        public LabMapper()
        {
            CreateMap<Lab, RecoverByIdResponse>();
            CreateMap<Lab, LabDto>();
            CreateMap<PagedResult<Lab>, FilterResponse>()
                .ForMember(dest => dest.Labs,
                    opt => opt.MapFrom(src => src.Data));
        }
    }
}