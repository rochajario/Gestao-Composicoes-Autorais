using ServiceStack.Host;

namespace Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces
{
    public interface IExceptionStrategyContextHandler
    {
        void LancaException(IExceptionStrategy strategy);
    }
}