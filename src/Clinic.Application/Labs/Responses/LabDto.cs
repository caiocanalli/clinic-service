using Clinic.Domain.Labs;

namespace Clinic.Application.Labs.Responses
{
    public class LabDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
    }
}