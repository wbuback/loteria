using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Megasena.Models
{
    public class Aposta
    {
        public Aposta(int[] dezenas, string surpresinha)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Data = DateTime.Now;

            if (surpresinha == "1")
            {                
                this.Dezenas = dezenas;
            }
            else
            {
                var randomicos = new Random();
                var dezenasSurpresinha = Enumerable.Range(1, 60).OrderBy(x => randomicos.Next()).Take(6).OrderBy(x => x);
                this.Dezenas = dezenasSurpresinha.ToArray();
            }
            
        }

        public string Id { get; set; }

        public DateTime Data { get; set; }

        public int[] Dezenas { get; set; }

        public bool Surpresinha { get; set; }


    }

   
}