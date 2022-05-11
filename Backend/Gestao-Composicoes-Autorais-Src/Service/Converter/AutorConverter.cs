using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using System;

namespace Gestao_Composicoes_Autorais_Src.Service.Converter
{
    public class AutorConverter : BaseConverter<AutorForm,Autor>
    {
        public AutorConverter(IExceptionStrategyContextHandler exceptionContextHandler):base(exceptionContextHandler)
        {
        }


        protected override Autor BuildModel(AutorForm input)
        {
            return new Autor
            {
                Nome = input.Nome,
                Categoria = (CategoriaAutoral)Enum.Parse(typeof(CategoriaAutoral), input.Categoria.ToUpper())
            };
        }
    }
}
