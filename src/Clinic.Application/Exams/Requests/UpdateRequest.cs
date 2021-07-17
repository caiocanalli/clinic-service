using System.Collections.Generic;
using Clinic.Domain.Exams;

namespace Clinic.Application.Exams.Requests
{
    public class UpdateRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ExamType Type { get; set; }
        public List<int> LabIds { get; set; }

        public UpdateRequest()
        {
            LabIds = new List<int>();
        }
    }
}