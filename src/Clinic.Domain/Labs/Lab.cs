using System.Collections.Generic;
using Clinic.Domain.Common;
using Clinic.Domain.Exams;

namespace Clinic.Domain.Labs
{
    public class Lab : AggregateRoot<int>
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public Status Status { get; private set; }
        public ICollection<Exam> Exams { get; private set; }

        protected Lab()
        {
        }

        public Lab(string name, string address)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("Name cannot be invalid");
            if (string.IsNullOrEmpty(address))
                throw new DomainException("Address cannot be invalid");

            Name = name;
            Address = address;
            Status = Status.Active;
        }

        public void UpdateInfos(string name, string address)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("Name cannot be invalid");
            if (string.IsNullOrEmpty(address))
                throw new DomainException("Address cannot be invalid");

            Name = name;
            Address = address;
        }

        public void Activate()
        {
            Status = Status.Active;
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }
    }
}