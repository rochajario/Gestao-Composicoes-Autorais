using System.Collections.Generic;

namespace Gestao_Composicoes_Autorais_Src.Model.Dtos
{
    public class MusicaDto
    {
        public long CodMusica { get; set; }
        public string Nome { get;  set; }
        public string Genero { get;  set; }
        public List<AutorDto> Autores { get; set; }
    }
}