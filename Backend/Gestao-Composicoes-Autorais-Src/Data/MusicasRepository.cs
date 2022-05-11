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
    public class MusicasRepository : BaseRepository, IMusicasRepository
    {
        public MusicasRepository(ApplicationContext database,
            IExceptionStrategyContextHandler exceptionContextHandler) : base(database, exceptionContextHandler) { }

        public void Create(Musica item)
        {
            _database.Musicas.Add(item);
            _database.SaveChanges();
        }

        public void Delete(long id)
        {
            var item = GetById(id);
            _database.Remove(item);
            _database.SaveChanges();
        }

        public virtual List<Musica> GetAll()
        {
            var result = _database.Musicas.ToList();
            if (result.Count == 0)
            {
                _exceptionContextHandler.LancaException(new NotFoundExceptionStrategy());
            }
            return result;
        }

        public virtual Musica GetById(long id)
        {
            var result = _database.Musicas.FirstOrDefault(m => m.Id == id);
            if (result == null)
            {
                _exceptionContextHandler.LancaException(new NotFoundExceptionStrategy());
            }
            return result;
        }

        public void Update(Musica item)
        {
            _database.Musicas.Update(item);
            _database.SaveChanges();
        }
    }
}
