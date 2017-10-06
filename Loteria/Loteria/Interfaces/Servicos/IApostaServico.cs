using Megasena.Models;
using System.Collections.Generic;

namespace Megasena.Interfaces.Servicos
{
    public interface IApostaServico
    {
        void AdicionarAposta(int[] dezenas, string supresinha);
        List<Aposta> ListarApostas();

        void Reiniciar();
    }
}
