using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Service.ControllerService
{
    public class AutorControllerService : BaseControllerService<Autor,AutorForm>, IAutorService
    {
        private readonly IAutoresRepository _autoresRepository;
        private readonly AutorConverter _autorConverter;

        public AutorControllerService(
            IAutoresRepository autoresRepository,
            AutorConverter autorConverter)
        {
            _autoresRepository = autoresRepository;
            _autorConverter = autorConverter;
        }

        public virtual ObjectResult ObterTodosItens()
        {
            var result = _autoresRepository.GetAll();
            return ObterObjetoRetornoEmpacotado(result, HttpStatusCode.OK);
        }

        public virtual ObjectResult AdicionarNovoItem(AutorForm form)
        {
            Autor novoAutor = _autorConverter.Convert(form);
            _autoresRepository.Create(novoAutor);
            return ObterObjetoRetornoEmpacotado(novoAutor, HttpStatusCode.Created);

        }

        public virtual ObjectResult ObterItemPorId(long id)
        {
            var autor = _autoresRepository.GetById(id);
            return ObterObjetoRetornoEmpacotado(autor, HttpStatusCode.OK);
        }

        public virtual ObjectResult AtualizarItem(long id, AutorForm form)
        {
            Autor dadosAtualizadosAutor = AtualizaDadosDeItemEmMemoria(id, form);
            _autoresRepository.Update(dadosAtualizadosAutor);
            return ObterObjetoRetornoEmpacotado(dadosAtualizadosAutor, HttpStatusCode.OK);
        }

        public ObjectResult RemoverItem(long id)
        {
            _autoresRepository.Delete(id);
            return ObterObjetoRetornoEmpacotado(null, HttpStatusCode.NoContent);
        }

        protected override Autor AtualizaDadosDeItemEmMemoria(long id, AutorForm form)
        {
            Autor dadosFormulario = _autorConverter.Convert(form);
            Autor dadosBanco = _autoresRepository.GetById(id);

            dadosBanco.Nome = dadosFormulario.Nome;
            dadosBanco.Categoria = dadosFormulario.Categoria;
            return dadosBanco;
        }
    }
}
