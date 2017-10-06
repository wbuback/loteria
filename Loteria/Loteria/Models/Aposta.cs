using System;

namespace Megasena.Models
{
    public class Aposta
    {
        public Aposta(int[] dezenas)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Data = DateTime.Now;
            this.Dezenas = dezenas;
        }

        public string Id { get; set; }

        public DateTime Data { get; set; }

        public int[] Dezenas { get; set; }
    }

   
}