using SmartTimer.Dominio.Usuarios.Entidades;
using SmartTimer.Dominio.Utils.Repositorios;

namespace SmartTimer.Dominio.Usuarios.Repositorios
{
    public interface IUsuariosRepositorio : IRepositorioNHibernate<Usuario>
    {
    }
}
