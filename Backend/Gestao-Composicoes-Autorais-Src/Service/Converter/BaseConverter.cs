using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.Converter;
using System;

namespace Gestao_Composicoes_Autorais_Src.Service.Converter
{
    public abstract class BaseConverter<Tin, Tout> : IConversion<Tin, Tout>
    {
        protected IExceptionStrategyContextHandler _exceptionContextHandler;
        public BaseConverter(IExceptionStrategyContextHandler exceptionContextHandler)
        {
            _exceptionContextHandler = exceptionContextHandler;
        }

        public virtual Tout Convert(Tin input)
        {
            try
            {
                return BuildModel(input);
            }
            catch (ArgumentException innerException)
            {
                _exceptionContextHandler.LancaException(new UnprocessableEntityStrategy(innerException));
                return default;
            }
        }

        protected abstract Tout BuildModel(Tin input);

    }
}
