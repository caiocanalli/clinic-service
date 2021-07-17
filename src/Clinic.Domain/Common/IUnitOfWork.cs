using System;

namespace Clinic.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Commit();
        void Rollback();
    }
}