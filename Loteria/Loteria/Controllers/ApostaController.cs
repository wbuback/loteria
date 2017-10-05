using Megasena.Models;
using Megasena.Servicos;
using System.Web.Mvc;

namespace Megasena.Controllers
{
    public class ApostaController : Controller
    {

        private readonly IApostaServico _apostaServico;
        public ApostaController(IApostaServico apostaServico)
        {
            _apostaServico = apostaServico;
        }

        // GET: Aposta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FazerAposta(ApostaModel model)
        {



            //_apostaServico.AdicionarAposta(model);
            return null;
        }
    }
}