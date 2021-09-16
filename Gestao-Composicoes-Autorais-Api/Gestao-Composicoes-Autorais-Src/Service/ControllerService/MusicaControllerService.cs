using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Gestao_Composicoes_Autorais_Src.Service.Interfaces.ControllerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Service.ControllerService
{
    public class MusicaControllerService : BaseControllerService<Musica,MusicaForm>, IMusicaService
    {
        private readonly MusicaConverter _musicaConverter;
        private readonly IMusicasRepository _musicasRepository;

        public MusicaControllerService(MusicaConverter musicaConverter, IMusicasRepository musicasRepository)
        {
            _musicaConverter = musicaConverter;
            _musicasRepository = musicasRepository;
        }

        public ObjectResult AdicionarNovoItem(MusicaForm form)
        {
            var objetoCriado = _musicaConverter.Convert(form);
            _musicasRepository.Create(objetoCriado);
            return ObterObjetoRetornoEmpacotado(objetoCriado, HttpStatusCode.Created);
        }

        public ObjectResult AtualizarItem(long id, MusicaForm form)
        {
            var dadosAtualizadosDaMusica = AtualizaDadosDeItemEmMemoria(id, form);
            _musicasRepository.Update(dadosAtualizadosDaMusica);
            return ObterObjetoRetornoEmpacotado(dadosAtualizadosDaMusica, HttpStatusCode.OK);
        }

        public ObjectResult ObterItemPorId(long id)
        {
            var musica = _musicasRepository.GetById(id);
            return ObterObjetoRetornoEmpacotado(musica, HttpStatusCode.OK);
        }

        public ObjectResult ObterTodosItens()
        {
            var listagemMusicas = _musicasRepository.GetAll();
            return ObterObjetoRetornoEmpacotado(listagemMusicas, HttpStatusCode.OK);
        }

        public ObjectResult RemoverItem(long id)
        {
            _musicasRepository.Delete(id);
            return ObterObjetoRetornoEmpacotado(null, HttpStatusCode.NoContent);
        }

        protected override Musica AtualizaDadosDeItemEmMemoria(long id, MusicaForm form)
        {
            Musica dadosFormulario = _musicaConverter.Convert(form);
            Musica dadosBanco = _musicasRepository.GetById(id);

            dadosBanco.Nome = dadosFormulario.Nome;
            dadosBanco.Genero = dadosFormulario.Genero;
            return dadosBanco;
        }
    }
}
