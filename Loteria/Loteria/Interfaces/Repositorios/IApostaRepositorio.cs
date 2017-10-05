using System;
using Megasena.Models;

namespace Megasena.Interfaces.Repositorios
{
    public interface IApostaRepositorio
    {
        ApostaModel AdicionarAposta(ApostaModel model);
    }
}
