using Megasena.Models;
using Megasena.Repositorios;

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

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}