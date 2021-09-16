using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Microsoft.AspNetCore.Mvc;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService;

namespace Gestao_Composicoes_Autorais_Src.Controllers
{

    [ApiController]
    [Route("/autores")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            return _autorService.ObterTodosItens();
        }

        [HttpGet("{id}")]
        public ObjectResult Get(long id)
        {
            return _autorService.ObterItemPorId(id);
        }

        [HttpPost]
        public ObjectResult Post([FromBody] AutorForm form)
        {
            return _autorService.AdicionarNovoItem(form);
        }

        [HttpPut("{id}")]
        public ObjectResult Put(long id, [FromBody] AutorForm form)
        {
            return _autorService.AtualizarItem(id, form);
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(long id)
        {
            return _autorService.RemoverItem(id);
        }
    }
}
