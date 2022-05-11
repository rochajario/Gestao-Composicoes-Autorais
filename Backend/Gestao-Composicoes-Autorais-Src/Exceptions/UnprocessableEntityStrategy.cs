using Gestao_Composicoes_Autorais_Src.Constants;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using ServiceStack.Host;
using System;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Exceptions
{
    public class UnprocessableEntityStrategy : IExceptionStrategy
    {
        private readonly ArgumentException _innerException;

        public UnprocessableEntityStrategy(ArgumentException innerException)
        {
            _innerException = innerException;
        }

        public void Execute()
        {
            throw new HttpException((int)HttpStatusCode.UnprocessableEntity, String.Format(MensagensErro.ParametroInvalido, _innerException.ParamName));
        }
    }
}
