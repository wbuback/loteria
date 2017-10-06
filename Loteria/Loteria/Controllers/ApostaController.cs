﻿using Megasena.Interfaces.Servicos;
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
        public ActionResult FazerAposta(int[] dezenas)
        {
            _apostaServico.AdicionarAposta(dezenas);
            return Json("Apostas realizadas. Falta pouco pra você ficar rico!", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ConferirApostas()
        {
            var sorteio = _sorteioServico.ObterUltimo();
            var apostas = _apostaServico.ListarApostas();

            int[] dezenasSorteio = null;

            if (sorteio == null)
            {
                return Json("Calma aê, apressadinho! Não teve sorteio ainda.", JsonRequestBehavior.AllowGet);
            }
            else if(apostas == null)
            {
                return Json("Véi, na boa... <br> Não acredito que você esqueceu de jogar!!!", JsonRequestBehavior.AllowGet);
            }
            else
            {
                dezenasSorteio = sorteio.Dezenas;
                List<Resultado> listaResultado = null;
                
                foreach (var item in apostas)
                {
                    var dezenasAposta = item.Dezenas;
                    //var conferencia = dezenasAposta.Intersect(dezenasSorteio);


                    var aConferir = new HashSet<int>(dezenasSorteio);
                    var conferidos = dezenasAposta.Where(aConferir.Contains);
                    int[] acertos = null;

                    if (conferidos.Any())
                        acertos = conferidos.ToArray();


                    listaResultado.Add(new Resultado {
                        Aposta = item,
                        Sorteio = sorteio,
                        acertos = acertos
                    });
                    
                }
                return Json(listaResultado, JsonRequestBehavior.AllowGet);
            }
        }
    }
}