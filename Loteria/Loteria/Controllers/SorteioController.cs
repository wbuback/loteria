using Megasena.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Megasena.Controllers
{
    public class SorteioController : Controller
    {
        private readonly ISorteioServico _sorteioServico;
        public SorteioController(ISorteioServico sorteioServico)
        {
            _sorteioServico = sorteioServico;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sortear()
        {
            var resultado = _sorteioServico.Sortear();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}