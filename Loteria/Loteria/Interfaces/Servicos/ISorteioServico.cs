using Megasena.Models;

namespace Megasena.Interfaces.Servicos
{
    public interface ISorteioServico
    {
        Sorteio Sortear();
        Sorteio ObterUltimo();
    }
}
