using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Repositories;

namespace ControleFinanceiro.Controllers
{
    public class HomeController : Controller
    {
        private ITransacaoRepository _repository;
        public HomeController(ITransacaoRepository repository)
        {
            this._repository = repository;
        }

        public IActionResult Listar()
        {
            var transacoes = this._repository.GetTransacoes();

            return View("Detalhes", transacoes);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserir(Transacao transacao)
        {
            this._repository.AddTransacao(transacao);

            var transacoes = this._repository.GetTransacoes();
            return View("Detalhes", transacoes);
        }


    }
}
