using SmartTimer.Dominio.Utils.Excecoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SmartTimer.IoC.Filtros
{
    public class RegraDeNegocioExcecaoFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is RegraDeNegocioExcecao regraDeNegocioExcecao)
            {
                var mensagem = regraDeNegocioExcecao.Message;
                var objeto = regraDeNegocioExcecao.GetType().Name;

                var result = new ObjectResult(new { mensagem, objeto })
                {
                    StatusCode = 400
                };
                context.Result = result;
            }
        }
    }
}
