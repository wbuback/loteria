using Megasena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megasena.Repositorios
{
    public interface IApostaRepositorio : IDisposable
    {
        ApostaModel AdicionarAposta(ApostaModel model);
    }
}
