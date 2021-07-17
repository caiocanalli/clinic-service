using Clinic.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace Clinic.Infra.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        IDbContextTransaction _transaction;

        public Context Context { get; }

        public UnitOfWork(Context context)
        {
            Context = context;
        }

        public void InitializeContext(bool usingTransaction)
        {
            if (usingTransaction)
                InitializeTransaction();
        }

        private void InitializeTransaction() =>
            _transaction = Context.Database.BeginTransaction();

        public void Save() =>
            Context?.SaveChanges();

        public void Commit()
        {
            Context?.SaveChanges();
            _transaction?.Commit();
        }

        public void Rollback() =>
            _transaction?.Rollback();

        public void Dispose()
        {
            _transaction?.Dispose();
            Context?.Dispose();
        }
    }
}