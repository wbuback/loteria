using Megasena.Interfaces.Servicos;
using Megasena.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Megasena.Controllers
{
    public class ApostaController : Controller
    {
        private readonly IApostaServico _apostaServico;
        private readonly ISorteioServico _sorteioServico;

        public ApostaController(IApostaServico apostaServico, ISorteioServico sorteioServico)
        {
            _apostaServico = apostaServico;
            _sorteioServico = sorteioServico;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarApostas()
        {
            var apostas = _apostaServico.ListarApostas();
            var json = JsonConvert.SerializeObject(apostas, new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy - HH:mm:ss" });
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FazerAposta(int[] dezenas, string supresinha)
        {
            _apostaServico.AdicionarAposta(dezenas, supresinha);
            return Json("Apostas realizadas. Falta pouco pra você ficar rico!", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Conferir()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConferirApostas()
        {
            var sorteio = _sorteioServico.ObterUltimo();    
            var apostas = _apostaServico.ListarApostas();

            if (sorteio == null)
            {
                return Json(new { erro = true, msg = "Calma aê, apressadinho! Não teve sorteio ainda." }, JsonRequestBehavior.AllowGet);
            }
            else if(!apostas.Any())
            {
                return Json(new { erro = true, msg = "Não acredito que você esqueceu de jogar!!!"}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int[] dezenasSorteio = null;
                dezenasSorteio = sorteio.Dezenas;
                List<Resultado> listaResultado = new List<Resultado>();
                
                foreach (var item in apostas)
                {
                    var dezenasAposta = item.Dezenas;

                    int[] acertos = dezenasAposta.Intersect(dezenasSorteio).ToArray();

                    listaResultado.Add(new Resultado {
                        Aposta = item,
                        Sorteio = sorteio,
                        acertos = acertos
                    });
                    
                }
                return Json(listaResultado, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult Reiniciar()
        {
            _apostaServico.Reiniciar();

            return Json("O jogo reiniciou. É sua hora de ganhar... ou continuar tentando!", JsonRequestBehavior.AllowGet);
        }
    }
}