using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megasena.Models
{
    public class Resultado
    {
        public Aposta Aposta { get; set; }
        public Sorteio Sorteio { get; set; }

        public int[] acertos { get; set; }


    }
}