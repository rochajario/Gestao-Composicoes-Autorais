using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService;
using Microsoft.AspNetCore.Mvc;

namespace Gestao_Composicoes_Autorais_Src.Controllers
{
    [Route("/musicas")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly IMusicaService _musicaService;

        public MusicaController(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            return _musicaService.ObterTodosItens();
        }

        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            return _musicaService.ObterItemPorId(id);
        }

        [HttpPost]
        public ObjectResult Post([FromBody] MusicaForm form)
        {
            return _musicaService.AdicionarNovoItem(form);
        }

        [HttpPut("{id}")]
        public ObjectResult Put(long id, [FromBody] MusicaForm form)
        {
            return _musicaService.AtualizarItem(id, form);
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            return _musicaService.RemoverItem(id);
        }
    }
}
