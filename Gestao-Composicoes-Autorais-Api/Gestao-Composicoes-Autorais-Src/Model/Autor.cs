using Gestao_Composicoes_Autorais_Src.Model.Enums;

namespace Gestao_Composicoes_Autorais_Src.Model
{
    public class Autor
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public CategoriaAutoral Categoria { get; set; }
    }
}