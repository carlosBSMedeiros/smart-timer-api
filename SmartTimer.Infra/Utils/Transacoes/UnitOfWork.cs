using SmartTimer.Dominio.Utils.Transacoes;
using NHibernate;

namespace SmartTimer.Infra.Utils.Transacoes
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession session;
        private ITransaction transaction;

        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        public void BeginTransaction()
        {
            this.transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null && transaction.IsActive)
            {
                transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (transaction != null && transaction.IsActive)
            {
                transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }

            if (session.IsOpen)
            {
                session.Close();
            }
        }
    }

}
