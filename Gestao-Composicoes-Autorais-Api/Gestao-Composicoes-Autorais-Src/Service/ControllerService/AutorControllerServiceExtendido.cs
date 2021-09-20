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
    public class AutorControllerServiceExtendido : AutorControllerService
    {
        public AutorControllerServiceExtendido(IAutoresRepository autoresRepository, AutorConverter autorConverter) : base(autoresRepository, autorConverter)
        {
        }

        public override ObjectResult ObterItemPorId(long id)
        {
            var autor = (Autor) base.ObterItemPorId(id).Value;
            return ObterObjetoRetornoEmpacotado(autor.ToDto(), HttpStatusCode.OK);
        }

        public override ObjectResult AtualizarItem(long id, AutorForm form)
        {
            var autor = (Autor)base.AtualizarItem(id, form).Value;
            return ObterObjetoRetornoEmpacotado(autor.ToDto(), HttpStatusCode.OK);
        }

        public override ObjectResult AdicionarNovoItem(AutorForm form)
        {
            var autor = (Autor)base.AdicionarNovoItem(form).Value;
            return ObterObjetoRetornoEmpacotado(autor.ToDto(), HttpStatusCode.Created);
        }

        public override ObjectResult ObterTodosItens()
        {
            var listaAutores = (List<Autor>)base.ObterTodosItens().Value;
            var listaAutoresDto = new List<AutorDto>();
            foreach (var autor in listaAutores)
            {
                listaAutoresDto.Add(autor.ToDto());
            }
            return ObterObjetoRetornoEmpacotado(listaAutoresDto, HttpStatusCode.OK);

        }
    }
}
