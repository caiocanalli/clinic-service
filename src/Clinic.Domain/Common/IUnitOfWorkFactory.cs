namespace Clinic.Domain.Common
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork StartUnitOfWork(bool usingTransaction = false);
    }
}