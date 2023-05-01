namespace SmartTimer.Dominio.Utils.Transacoes
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }

}
