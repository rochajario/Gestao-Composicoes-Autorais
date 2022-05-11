using Gestao_Composicoes_Autorais_Src.Data.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Dtos;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using Gestao_Composicoes_Autorais_Src.Service.Converter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Gestao_Composicoes_Autorais_Src.Service.ControllerService
{
    public class MusicaControllerServiceExtendido : MusicaControllerService
    {
        private readonly IAutoresRepository _autoresRepository;
        public MusicaControllerServiceExtendido(MusicaConverter musicaConverter, IMusicasRepository musicasRepository, IAutoresRepository autoresRepository) : base(musicaConverter, musicasRepository)
        {
            _autoresRepository = autoresRepository;
        }

        private List<Autor> ObterAutores(MusicaForm form)
        {
            var autores = new List<Autor>();
            foreach (var autorId in form.CodAutores)
            {
                var autor = _autoresRepository.GetById(autorId);
                autores.Add(autor);
            }
            return autores;
        }

        public override ObjectResult AtualizarItem(long id, MusicaForm form)
        {
            var musicaAAtualizar = (Musica) base.AtualizarItem(id, form).Value;
            musicaAAtualizar.Autores = ObterAutores(form);
            _musicasRepository.Update(musicaAAtualizar);
            return ObterObjetoRetornoEmpacotado(musicaAAtualizar.ToDto(), HttpStatusCode.OK);
        }

        public override ObjectResult ObterTodosItens()
        {
            var listaDeMusicas = (List<Musica>) base.ObterTodosItens().Value;
            
            var listagemMusicasDto = new List<MusicaDto>();
            foreach (var musica in listaDeMusicas)
            {
                listagemMusicasDto.Add(musica.ToDto());
            }

            return ObterObjetoRetornoEmpacotado(listagemMusicasDto, HttpStatusCode.OK);
        }

        public override ObjectResult ObterItemPorId(long id)
        {
            var musica = (Musica) base.ObterItemPorId(id).Value;
            return ObterObjetoRetornoEmpacotado(musica.ToDto(), HttpStatusCode.OK);
        }

        public override ObjectResult AdicionarNovoItem(MusicaForm form)
        {
            var musica = _musicaConverter.Convert(form);
            musica.Autores = ObterAutores(form);
            _musicasRepository.Create(musica);
            return ObterObjetoRetornoEmpacotado(musica.ToDto(), HttpStatusCode.Created);
        }
    }
}
