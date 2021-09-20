using Gestao_Composicoes_Autorais_Src.Data.Context;
using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Gestao_Composicoes_Autorais_Src.Data
{
    public class MusicasRepositoryExtendido : MusicasRepository
    {
        public MusicasRepositoryExtendido(ApplicationContext database, IExceptionStrategyContextHandler exceptionContextHandler) : base(database, exceptionContextHandler)
        {
        }

        public override List<Musica> GetAll()
        {
            var result = _database.Musicas.Include(m => m.Autores).ToList();
            if (result.Count == 0)
            {
                _exceptionContextHandler.LancaException(new NotFoundExceptionStrategy());
            }
            return result;
        }

        public override Musica GetById(long id)
        {
            var result = _database.Musicas.Include(m => m.Autores).FirstOrDefault(m => m.Id == id);
            if (result == null)
            {
                _exceptionContextHandler.LancaException(new NotFoundExceptionStrategy());
            }
            return result;
        }
    }
}
