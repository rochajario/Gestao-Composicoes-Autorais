using Gestao_Composicoes_Autorais_Src.Model;

namespace Gestao_Composicoes_Autorais_Src.Data.Interfaces
{
    public interface IAutoresRepository : ICommand<Autor>, IQuery<Autor>
    {
    }
}
