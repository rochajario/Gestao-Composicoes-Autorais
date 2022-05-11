using System.Threading.Tasks;

namespace Gestao_Composicoes_Autorais_Src.Data.Interfaces
{
    public interface ICommand<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(long id);
    }
}
