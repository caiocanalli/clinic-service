using System.Collections.Generic;
using Clinic.Domain.Exams;

namespace Clinic.Application.Exams.Requests
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public ExamType Type { get; set; }
        public List<int> LabIds { get; set; }

        public RegisterRequest()
        {
            LabIds = new List<int>();
        }
    }
}