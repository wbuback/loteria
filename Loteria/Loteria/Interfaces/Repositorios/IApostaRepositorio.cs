using Megasena.Models;
using System.Collections.Generic;

namespace Megasena.Interfaces.Repositorios
{
    public interface IApostaRepositorio
    {
        void AdicionarAposta(Aposta dezenas);
        List<Aposta> ListarApostas();

        void Reiniciar();
    }
}
