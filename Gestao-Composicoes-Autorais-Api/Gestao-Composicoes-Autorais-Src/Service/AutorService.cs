using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Service
{
    public class AutorService : IAutorService
    {
        private IAutoresRepository _autoresRepository;
        private AutorConverter _autorConverter;

        public AutorService(
            IAutoresRepository autoresRepository, 
            AutorConverter autorConverter)
        {
            _autoresRepository = autoresRepository;
            _autorConverter = autorConverter;
        }

        public ObjectResult ObterTodosAutores()
        {
            var result = _autoresRepository.GetAll();
            return new ObjectResult(result) { StatusCode = (int)HttpStatusCode.OK };
        }

        public ObjectResult AdicionarNovoAutor(AutorForm form)
        {
            Autor novoAutor = _autorConverter.Convert(form);
            _autoresRepository.Create(novoAutor);
            return new ObjectResult(novoAutor) { StatusCode = (int)HttpStatusCode.Created };

        }
    }
}
