using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao_Composicoes_Autorais_Src.Data.Interfaces
{
    public interface IQuery<T>
    {
        List<T> GetAll();
        T GetById(long id);
    }
}
