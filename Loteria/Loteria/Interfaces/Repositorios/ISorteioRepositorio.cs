using Megasena.Models;
using System;

namespace Megasena.Interfaces.Repositorios
{
    public interface ISorteioRepositorio
    {
        void Sortear(Sorteio sorteio);
        Sorteio ObterUltimo();
    }
}