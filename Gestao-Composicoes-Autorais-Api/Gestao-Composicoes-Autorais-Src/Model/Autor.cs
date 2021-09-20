using Gestao_Composicoes_Autorais_Src.Model.Dtos;
using Gestao_Composicoes_Autorais_Src.Model.Enums;
using System;
using System.Collections.Generic;

namespace Gestao_Composicoes_Autorais_Src.Model
{
    public class Autor
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public CategoriaAutoral Categoria { get; set; }
        public ICollection<Musica> Musicas { get; set; }

        public AutorDto ToDto()
        {
            return new AutorDto
            {
                CodAutor = Id,
                Nome = Nome,
                Categoria = Enum.GetName(Categoria.GetType(), Categoria)
            };
        }
    }
}