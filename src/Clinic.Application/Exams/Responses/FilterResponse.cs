using System.Collections.Generic;

namespace Clinic.Application.Exams.Responses
{
    public class FilterResponse
    {
        public List<ExamDto> Exams { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalSize { get; set; }

        public FilterResponse()
        {
            Exams = new List<ExamDto>();
        }
    }
}