using Megasena.Interfaces.Repositorios;
using Megasena.Interfaces.Servicos;
using Megasena.Models;

namespace Megasena.Servicos
{
    public class SorteioServico : ISorteioServico
    {
        private readonly ISorteioRepositorio _sorteioRepositorio;
        public SorteioServico(ISorteioRepositorio sorteioRepositorio)
        {
            _sorteioRepositorio = sorteioRepositorio;
        }

        public Sorteio ObterUltimo()
        {
            return _sorteioRepositorio.ObterUltimo();
        }

        public Sorteio Sortear()
        {
            var sorteio = new Sorteio();
            _sorteioRepositorio.Sortear(sorteio);
            
            return sorteio;
        }

    }
}