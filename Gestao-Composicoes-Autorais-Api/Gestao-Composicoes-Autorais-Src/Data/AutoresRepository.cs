using Gestao_Composicoes_Autorais_Src.Data.Context;
using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gestao_Composicoes_Autorais_Src.Data
{
    public class AutoresRepository : BaseRepository, IAutoresRepository
    {
        public AutoresRepository(ApplicationContext database, 
            IExceptionStrategyContextHandler exceptionContextHandler) : base(database, exceptionContextHandler)
        {
        }

        public void Create(Autor item)
        {
            _database.Autores.Add(item);
            _database.SaveChanges();
        }

        public void Delete(long id)
        {
            var autor = GetById(id);
            _database.Remove(autor);
            _database.SaveChanges();
        }

        public List<Autor> GetAll()
        {
            var result = _database.Autores.ToList();
            if(result.Count == 0)
            {
                _exceptionContextHandler.LancaException(new NotFoundExceptionStrategy());
            }
            return result;
        }

        public Autor GetById(long id)
        {
            var result = _database.Autores.FirstOrDefault(a => a.Id == id);
            if(result == null)
            {
                _exceptionContextHandler.LancaException(new NotFoundExceptionStrategy());
            }
            return result;
        }

        public void Update(Autor item)
        {
            _database.Autores.Update(item);
            _database.SaveChanges();
        }
    }
}
