using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gestao_Composicoes_Autorais_Src.Controllers
{

    [ApiController]
    [Route("/autores")]
    public class AutorController : ControllerBase
    {
        private IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            return _autorService.ObterTodosAutores();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ObjectResult Post([FromBody] AutorForm form)
        {
            return _autorService.AdicionarNovoAutor(form);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
