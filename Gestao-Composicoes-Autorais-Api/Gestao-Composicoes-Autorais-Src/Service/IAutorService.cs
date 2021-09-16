using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Gestao_Composicoes_Autorais_Src.Service
{
    public interface IAutorService
    {
        ObjectResult ObterTodosAutores();
        ObjectResult AdicionarNovoAutor(AutorForm form);
    }
}
