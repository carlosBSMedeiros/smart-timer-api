using Microsoft.AspNetCore.Mvc;
using SmartTimer.Aplicacao.Usuarios.Servicos.Interfaces;
using SmartTimer.DataTransfer.Autenticacoes.Request;
using SmartTimer.DataTransfer.Auth.Response;

namespace SmartTimer.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacoesController : Controller
    {
        private readonly IUsuariosAppServico usuariosAppServico;

        public AutenticacoesController(IUsuariosAppServico usuariosAppServico)
        {
            this.usuariosAppServico = usuariosAppServico;
        }

        /// <summary>
        /// Realiza autenticação do usuário por email e senha
        /// </summary>
        /// <param name="request""></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AutenticacaoResponse> Login(AutenticacaoRequest request)
        {
            return Ok(usuariosAppServico.Autenticar(request));
        }
    }
}
