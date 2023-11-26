using Domain.Interfaces.Data;

namespace Application
{
    public class UnitOfWorkAppService
    {
        private readonly IUnitOfWork _uow;

        public UnitOfWorkAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }
        public void Commit(bool dispose = true)
        {
            _uow.Commit(dispose);
        }

        public void Rollback()
        {
            _uow.Rollback();
        }

        public void SaveChanges()
        {
            _uow.SaveChanges();
        }
    }
}
