using Megasena.Models;
using System.Collections.Generic;

namespace Megasena.Interfaces.Servicos
{
    public interface IApostaServico
    {
        void AdicionarAposta(int[] dezenas);
        List<Aposta> ListarApostas();
    }
}
