using SmartTimer.Aplicacao.Usuarios.Servicos.Interfaces;
using SmartTimer.DataTransfer.Usuarios.Request;
using SmartTimer.DataTransfer.Usuarios.Response;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosAppServico usuariosAppServico;

        public UsuariosController(IUsuariosAppServico usuariosAppServico)
        {
            this.usuariosAppServico = usuariosAppServico;
        }

        /// <summary>
        /// Recupera usuário pelo id
        /// </summary>
        /// <param name="codigo""></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{codigo:int}")]
        public ActionResult<UsuarioResponse> Get([FromRoute] int codigo)
        {
            var resultado = usuariosAppServico.Recuperar(codigo);
            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult<UsuarioResponse> Inserir(UsuarioInserirRequest request)
        {
            return usuariosAppServico.Inserir(request);
        }
    }
}
