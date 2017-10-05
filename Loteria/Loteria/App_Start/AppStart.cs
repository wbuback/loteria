using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megasena.App_Start
{
    public class AppStart
    {
        kernel.Bind(typeof(IApostaServico<>)).To(typeof(ApostaServico<>));
        kernel.Bind(typeof(ISorteioServico<>)).To(typeof(SorteioServico<>));

        kernel.Bind(typeof(IApostaRepositorio<>)).To(typeof(ApostaRepositorio<>));
        kernel.Bind(typeof(ISorteioRepositorio<>)).To(typeof(SorteioRepositorio<>));
    }


}