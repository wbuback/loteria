using Megasena.Models;
using System;

namespace Megasena.Servicos
{
    public interface IApostaServico : IDisposable
    {
        ApostaModel AdicionarAposta(ApostaModel model);
    }
}
