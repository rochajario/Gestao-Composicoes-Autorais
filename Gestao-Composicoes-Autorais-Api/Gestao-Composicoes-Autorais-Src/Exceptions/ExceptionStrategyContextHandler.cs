using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;

namespace Gestao_Composicoes_Autorais_Src.Exceptions
{
    public class ExceptionStrategyContextHandler : IExceptionStrategyContextHandler
    {
        public void LancaException(IExceptionStrategy strategy)
        {
            strategy.Execute();
        }
    }
}
