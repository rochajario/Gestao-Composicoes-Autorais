using System.ComponentModel.DataAnnotations;

namespace Gestao_Composicoes_Autorais_Src.Model.Forms
{
    public class AutorForm
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Categoria { get; set; }
    }
}
