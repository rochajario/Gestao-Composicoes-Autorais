using Gestao_Composicoes_Autorais_Src.Model.Dtos;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using System;
using System.Collections.Generic;

namespace Gestao_Composicoes_Autorais_Src.Model
{
    public class Musica
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public GeneroMusical Genero { get; set; }
        public ICollection<Autor> Autores { get; set; }

        public MusicaDto ToDto()
        {
            return new MusicaDto
            {
                CodMusica = Id,
                Nome = Nome,
                Genero = Enum.GetName(Genero.GetType(), Genero),
                Autores = ObterListaDeAutoresDto()
            };
        }

        public List<AutorDto> ObterListaDeAutoresDto()
        {
            if(Autores == default)
            {
                return default;
            }

            var autoresDto = new List<AutorDto>();
            foreach (var autor in Autores)
            {
                autoresDto.Add(autor.ToDto());
            }
            return autoresDto;
        }
    }
}
