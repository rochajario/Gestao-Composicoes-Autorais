using Gestao_Composicoes_Autorais_Src.Exceptions.Interfaces;
using Gestao_Composicoes_Autorais_Src.Model;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using Gestao_Composicoes_Autorais_Src.Model.Forms;
using System;

namespace Gestao_Composicoes_Autorais_Src.Service.Converter
{
    public class MusicaConverter : BaseConverter<MusicaForm, Musica>
    {
        public MusicaConverter(IExceptionStrategyContextHandler exceptionContextHandler):base(exceptionContextHandler)
        {
        }

        protected override Musica BuildModel(MusicaForm input)
        {
            return new Musica
            {
                Nome = input.Nome,
                Genero = (GeneroMusical)Enum.Parse(typeof(GeneroMusical), input.Genero.ToUpper())
            };
        }
    }
}
