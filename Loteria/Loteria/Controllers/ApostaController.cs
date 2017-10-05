using Megasena.Models;
using System.Web.Mvc;
using Megasena.Interfaces.Servicos;

namespace Megasena.Controllers
{
    public class ApostaController : Controller
    {
        private readonly IApostaServico _apostaServico;

        public ApostaController(IApostaServico apostaServico)
        {
            _apostaServico = apostaServico;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FazerAposta(ApostaModel model)
        {
            _apostaServico.AdicionarAposta(model);
            return null;
        }
    }
}