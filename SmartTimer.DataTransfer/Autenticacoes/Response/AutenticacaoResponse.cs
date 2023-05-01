using SmartTimer.DataTransfer.Usuarios.Response;

namespace SmartTimer.DataTransfer.Auth.Response
{
    public class AutenticacaoResponse
    {
        public UsuarioResponse Usuario { get; set; }
        public string Token { get; set; }

    }
}
