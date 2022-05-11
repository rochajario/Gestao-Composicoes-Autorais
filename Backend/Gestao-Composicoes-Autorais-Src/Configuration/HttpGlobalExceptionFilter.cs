using Gestao_Composicoes_Autorais_Src.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceStack.Host;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Configuration
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not HttpException)
            {
                context.Result = ObterRetornoErro();
            }
            else
            {
                HttpException exception = (HttpException)context.Exception;
                context.Result = ObterRetornoErro(exception);
            }
            context.ExceptionHandled = true;
        }

        protected ObjectResult ObterRetornoErro(HttpException exception = null)
        {
            if(exception != null)
            {
                return new ObjectResult(new ResultadoErro(exception.StatusDescription)) { StatusCode = exception.StatusCode };
            }

            return new ObjectResult(new ResultadoErro(MensagensErro.ErroInesperado)) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }
    }

    public class ResultadoErro
    {
        public string Erro { get; set; }
        public ResultadoErro(string mensagem)
        {
            Erro = mensagem;
        }
    }
}
