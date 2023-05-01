using SmartTimer.Dominio.Usuarios.Entidades;

namespace SmartTimer.Infra.Autenticacoes.Servicos.Interfaces
{
    public interface IAutenticacoesServico
    {
        public string GerarToken(Usuario usuario);
    }
}
