using System.Collections.Generic;
using Clinic.Domain.Exams;

namespace Clinic.Application.Exams.Responses
{
    public class RecoverByIdResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ExamType Type { get; set; }
        public Status Status { get; set; }
        public List<LabDto> Labs { get; set; }

        public RecoverByIdResponse()
        {
            Labs = new List<LabDto>();
        }
    }
}