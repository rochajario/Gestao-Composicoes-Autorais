using Microsoft.AspNetCore.Mvc;

namespace Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService
{
    public interface IControllerQueryService
    {
        ObjectResult ObterTodosItens();
        ObjectResult ObterItemPorId(long id);
    }
}
