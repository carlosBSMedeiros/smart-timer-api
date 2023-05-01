using SmartTimer.Dominio.Utils.Entidades;

namespace SmartTimer.Dominio.Utils.Repositorios
{
    public interface IRepositorioNHibernate<T> where T : EntidadeBase
    {
        public void Inserir(T entidade);
        public T Recuperar(int id);
        public IQueryable<T> Query();
        public void Deletar(T entidade);
        public void Deletar(int id);
        public void Editar(T entidade);
    }
}
