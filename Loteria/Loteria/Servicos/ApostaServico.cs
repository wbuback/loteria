using Megasena.Interfaces.Repositorios;
using Megasena.Interfaces.Servicos;
using Megasena.Models;
using System.Collections.Generic;

namespace Megasena.Servicos
{
    public class ApostaServico : IApostaServico
    {
        private readonly IApostaRepositorio _apostaRepositorio;

        public ApostaServico(IApostaRepositorio apostaRepositorio)
        {
            _apostaRepositorio = apostaRepositorio;
        }

        public void AdicionarAposta(int[] dezenas)
        {
            var aposta = new Aposta(dezenas);

            _apostaRepositorio.AdicionarAposta(aposta);
        }

        public List<Aposta> ListarApostas()
        {
            var apostas = _apostaRepositorio.ListarApostas();
            return apostas;
        }

    }
}