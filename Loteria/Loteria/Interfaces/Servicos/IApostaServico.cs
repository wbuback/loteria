using System;
using Megasena.Models;

namespace Megasena.Interfaces.Servicos
{
    public interface IApostaServico
    {
        ApostaModel AdicionarAposta(ApostaModel model);
    }
}
