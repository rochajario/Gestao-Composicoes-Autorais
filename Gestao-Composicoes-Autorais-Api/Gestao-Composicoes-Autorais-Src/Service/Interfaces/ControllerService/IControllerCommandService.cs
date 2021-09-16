using Microsoft.AspNetCore.Mvc;

namespace Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService
{
    public interface IControllerCommandService<Tform>
    {
        ObjectResult AdicionarNovoItem(Tform form);
        ObjectResult AtualizarItem(long id, Tform form);
        ObjectResult RemoverItem(long id);
    }
}
