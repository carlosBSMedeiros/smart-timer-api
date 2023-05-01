using SmartTimer.Dominio.Usuarios.Entidades;
using SmartTimer.Dominio.Usuarios.Repositorios;
using SmartTimer.Dominio.Usuarios.Servicos.Interfaces;
using SmartTimer.Dominio.Utils.Excecoes;

namespace SmartTimer.Dominio.Usuarios.Servicos
{
    public class UsuariosServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;

        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio)
        {
            this.usuariosRepositorio = usuariosRepositorio;
        }
        
        public Usuario Instanciar(string nome, string email, string senha)
        {
            return new(nome, email, senha);
        }

        public Usuario Validar(int id)
        {
            var usuario = usuariosRepositorio.Recuperar(id);
            if(usuario is null)
            {
                throw new RegraDeNegocioExcecao("Usuario não encontrado");
            }
            return usuario;
        }

        public void Inserir(Usuario usuario)
        {
            var usuarioExistente = usuariosRepositorio.Query().FirstOrDefault(x => x.Email.Equals(usuario.Email));
            if(usuarioExistente is not null)
            {
                throw new RegraDeNegocioExcecao("E-mail inválido");
            }

            var senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            usuario.SetSenha(senhaHash);
            usuario.SetDataCriacao(DateTime.Now);
            usuariosRepositorio.Inserir(usuario);
        }

        public Usuario ValidarParaAutenticacao(string email, string senha)
        {
            var mensagemErro = "E-mail ou senha incorretos";
            var usuarioEncontrado = usuariosRepositorio.Query().FirstOrDefault(u => u.Email == email);

            if (usuarioEncontrado is null)
                throw new RegraDeNegocioExcecao(mensagemErro);

            if (!BCrypt.Net.BCrypt.Verify(senha, usuarioEncontrado.Senha))
                throw new RegraDeNegocioExcecao(mensagemErro);

            return usuarioEncontrado;
        }
    }
}
