using Megasena.Interfaces.Repositorios;
using Megasena.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megasena.Repositorios
{
    public class ApostaRepositorio : IApostaRepositorio
    {
        public void AdicionarAposta(Aposta aposta)
        {
            if (aposta == null) return;

            List<Aposta> listaApostas = null;

            if (HttpContext.Current.Session["Jogos"] != null)
            {
                listaApostas = (List<Aposta>)HttpContext.Current.Session["Jogos"];
            } else
            {
                listaApostas = new List<Aposta>();
            }
            listaApostas.Add(aposta);
            HttpContext.Current.Session["Jogos"] = listaApostas.ToList();
        }

        public List<Aposta> ListarApostas()
        {
            if (HttpContext.Current.Session["Jogos"] == null) return new List<Aposta>();
            return (List<Aposta>)HttpContext.Current.Session["Jogos"];
        }

        public void Reiniciar()
        {
            HttpContext.Current.Session["Jogos"] = null;
            HttpContext.Current.Session["Sorteio"] = null;
        }
    }
}