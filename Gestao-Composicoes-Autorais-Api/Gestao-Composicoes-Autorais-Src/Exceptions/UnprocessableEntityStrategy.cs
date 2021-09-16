using Gestao_Composicoes_Autorais_Src.Constants;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using ServiceStack.Host;
using System;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Exceptions
{
    public class UnprocessableEntityStrategy : IExceptionStrategy
    {
        private ArgumentException innerException;

        public UnprocessableEntityStrategy(ArgumentException innerException)
        {
            this.innerException = innerException;
        }

        public void Execute()
        {
            throw new HttpException((int)HttpStatusCode.UnprocessableEntity, String.Format(MensagensErro.ParametroInvalido, this.innerException.ParamName));
        }
    }
}
