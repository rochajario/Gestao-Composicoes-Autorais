using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceStack.Host;
using System.Net;
using Gestao_Composicoes_Autorais_Src.Constants;

namespace Gestao_Composicoes_Autorais_Src.Configuration
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not HttpException)
            {
                context.Result = new ObjectResult(MensagensErro.ErroInesperado) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
            else
            {
                HttpException ex = (HttpException)context.Exception;
                context.Result = new ObjectResult(ex.StatusDescription) { StatusCode = ex.StatusCode };
            }
            context.ExceptionHandled = true;
        }
    }
}
