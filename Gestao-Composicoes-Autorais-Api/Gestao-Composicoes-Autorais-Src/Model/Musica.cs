using Gestao_Composicoes_Autorais_Src.Model.Enums;

namespace Gestao_Composicoes_Autorais_Src.Model
{
    public class Musica
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public GeneroMusical Genero { get; set; }
    }
}
