using Clinic.Domain.Labs;

namespace Clinic.Application.Labs.Requests
{
    public class FilterRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}