using Clinic.Domain.Common;

namespace Clinic.Infra.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork StartUnitOfWork(bool usingTransaction = false)
        {
            ((UnitOfWork) _unitOfWork).InitializeContext(usingTransaction);
            return _unitOfWork;
        }
    }
}