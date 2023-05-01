using SmartTimer.Dominio.Usuarios.Entidades;

namespace SmartTimer.Dominio.Usuarios.Servicos.Interfaces
{
    public  interface IUsuariosServico
    {
        Usuario Validar(int id);
        Usuario Instanciar(string nome, string email, string senha);
        void Inserir(Usuario usuario);
        Usuario ValidarParaAutenticacao(string email, string senha);
    }
}
