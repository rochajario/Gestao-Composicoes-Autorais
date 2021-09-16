using Gestao_Composicoes_Autorais_Src.Constants;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using ServiceStack.Host;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Exceptions
{
    public class NotFoundExceptionStrategy : IExceptionStrategy
    {
        public void Execute()
        {
            throw new HttpException((int)HttpStatusCode.NotFound, MensagensErro.NotFound);
        }
    }
}
