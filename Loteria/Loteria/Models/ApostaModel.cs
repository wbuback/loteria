using System;
using System.Collections.Generic;

namespace Megasena.Models
{
    public class ApostaModel
    {
        public List<Jogos> Jogos { get; set; }
    }

    public class Jogos
    {
        public Array Dezenas { get; set; }
    }
}