using FluentNHibernate.Mapping;
using SmartTimer.Dominio.Usuarios.Entidades;

namespace SmartTimer.Infra.Usuarios.Mapeamentos
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("usuario");
            Id(x => x.Id).Column("id").GeneratedBy.Identity();
            Map(u => u.Nome, "nome");
            Map(u => u.Email, "email");
            Map(u => u.Senha, "senha");
            Map(u => u.DataCriacao, "create_at");
            Map(u => u.DataAtualizacao, "update_at");
        }
    }
}
