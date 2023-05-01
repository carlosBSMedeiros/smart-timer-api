using SmartTimer.Dominio.Usuarios.Entidades;
using SmartTimer.Dominio.Usuarios.Repositorios;
using SmartTimer.Infra.Utils.Repositorios;
using NHibernate;

namespace SmartTimer.Infra.Usuarios.Repositorios
{
    public class UsuariosRepositorio : RepositorioNHibernate<Usuario>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(ISession session) : base(session)
        {

        }
    }
}
