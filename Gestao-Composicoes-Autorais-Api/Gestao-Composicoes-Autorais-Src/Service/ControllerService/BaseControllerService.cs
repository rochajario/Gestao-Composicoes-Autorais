using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Service.ControllerService
{
    public abstract class BaseControllerService<T,Tform>
    {
        protected ObjectResult ObterObjetoRetornoEmpacotado(object payload, HttpStatusCode statusCode)
        {
            var code = Convert.ToInt32(statusCode);
            return new ObjectResult(payload) { StatusCode = code };
        }

        protected abstract T AtualizaDadosDeItemEmMemoria(long id, Tform form);
    }
}
