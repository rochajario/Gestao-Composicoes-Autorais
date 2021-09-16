using Gestao_Composicoes_Autorais_Src.Data.Context;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;

namespace Gestao_Composicoes_Autorais_Src.Data
{
    public class BaseRepository
    {
        protected ApplicationContext _database;
        protected IExceptionStrategyContextHandler _exceptionContextHandler;

        public BaseRepository(ApplicationContext database, IExceptionStrategyContextHandler exceptionContextHandler)
        {
            _database = database;
            _exceptionContextHandler = exceptionContextHandler;
        }
    }
}
