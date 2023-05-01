using SmartTimer.DataTransfer.Autenticacoes.Request;
using SmartTimer.DataTransfer.Auth.Response;
using SmartTimer.DataTransfer.Usuarios.Request;
using SmartTimer.DataTransfer.Usuarios.Response;

namespace SmartTimer.Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosAppServico 
    {
        UsuarioResponse Recuperar(int id);
        UsuarioResponse Inserir(UsuarioInserirRequest request);
        AutenticacaoResponse Autenticar(AutenticacaoRequest request);
    }
}
