﻿using System.Collections.Generic;

namespace Gestao_Composicoes_Autorais_Src.Model.Forms
{
    public class MusicaForm
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public List<long> CodAutores { get; set; }
    }
}