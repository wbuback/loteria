using Megasena.Interfaces.Repositorios;
using Megasena.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megasena.Repositorios
{
    public class SorteioRepositorio : ISorteioRepositorio
    {
        public Sorteio ObterUltimo()
        {
            if (HttpContext.Current.Session["Sorteio"] == null) {
                return null;
            } else {
                var listarSorteios = (List<Sorteio>)HttpContext.Current.Session["Sorteio"];
                return listarSorteios.LastOrDefault();
            }
               
        }

        public void Sortear(Sorteio sorteio)
        {
            List<Sorteio> listarSorteios = null;

            if (HttpContext.Current.Session["Sorteio"] != null)
            {
                listarSorteios = (List<Sorteio>)HttpContext.Current.Session["Sorteio"];
            }
            else
            {
                listarSorteios = new List<Sorteio>();
            }

            listarSorteios.Add(sorteio);
            HttpContext.Current.Session["Sorteio"] = listarSorteios.ToList();
        }


    }
}