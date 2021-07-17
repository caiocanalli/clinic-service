using AutoMapper;
using Clinic.Application.Exams.Responses;
using Clinic.Domain.Common;
using Clinic.Domain.Exams;
using Clinic.Domain.Labs;

namespace Clinic.Application.Exams
{
    public class ExamMapper : Profile
    {
        public ExamMapper()
        {
            CreateMap<Exam, RecoverByIdResponse>();
            CreateMap<Exam, ExamDto>();
            CreateMap<Lab, LabDto>();
            CreateMap<PagedResult<Exam>, FilterResponse>()
                .ForMember(dest => dest.Exams,
                    opt => opt.MapFrom(src => src.Data));
        }
    }
}