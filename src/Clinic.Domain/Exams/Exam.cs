using System.Collections.Generic;
using Clinic.Domain.Common;
using Clinic.Domain.Labs;

namespace Clinic.Domain.Exams
{
    public class Exam : AggregateRoot<long>
    {
        public string Name { get; private set; }
        public ExamType Type { get; private set; }
        public Status Status { get; private set; }
        public ICollection<Lab> Labs { get; private set; }

        protected Exam()
        {
        }

        public Exam(string name, ExamType type, List<Lab> labs)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("Name cannot be invalid");
            if (type == ExamType.None)
                throw new DomainException("Type cannot be invalid");
            if (labs.Count == 0)
                throw new DomainException("Labs cannot be 0");

            Name = name;
            Type = type;
            Status = Status.Active;
            Labs = new List<Lab>(labs);
        }

        public void Activate()
        {
            Status = Status.Active;
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }

        public void UpdateInfos(string name, ExamType type, List<Lab> labs)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("Name cannot be invalid");
            if (type == ExamType.None)
                throw new DomainException("Type cannot be invalid");
            if (labs.Count == 0)
                throw new DomainException("Labs cannot be 0");

            Name = name;
            Type = type;
            Labs = new List<Lab>(labs);
        }
    }
}