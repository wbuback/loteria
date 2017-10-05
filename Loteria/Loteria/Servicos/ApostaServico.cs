using Megasena.Interfaces.Repositorios;
using Megasena.Interfaces.Servicos;
using Megasena.Models;

namespace Megasena.Servicos
{
    public class ApostaServico : IApostaServico
    {
        private readonly IApostaRepositorio _apostaRepositorio;

        public ApostaServico(IApostaRepositorio apostaRepositorio)
        {
            _apostaRepositorio = apostaRepositorio;
        }

        public ApostaModel AdicionarAposta(ApostaModel model)
        {
            return _apostaRepositorio.AdicionarAposta(model);
        }

    }
}