using System.Collections.Generic;

namespace Clinic.Application.Labs.Responses
{
    public class FilterResponse
    {
        public List<LabDto> Labs { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalSize { get; set; }

        public FilterResponse()
        {
            Labs = new List<LabDto>();
        }
    }
}