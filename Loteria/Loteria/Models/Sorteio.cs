using System;
using System.Linq;

namespace Megasena.Models
{
    public class Sorteio
    {
        public Sorteio()
        {
            var randomicos = new Random();
            var numerosSorteados = Enumerable.Range(1, 60).OrderBy(x => randomicos.Next()).Take(6).OrderBy(x=>x);
            this.Dezenas = numerosSorteados.ToArray();
            this.Data = DateTime.Now;
        }

        public int[] Dezenas { get; set; }
        public DateTime Data { get; set; }
    }
}