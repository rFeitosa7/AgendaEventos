using System.Diagnostics;
using Agendamento_de_Eventos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento_de_Eventos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GrupoCasamento()
        {
            string mensagemWhatsappCasamento = "Olá gostaria de fazer um orçamento para uma cerimônia de casamento";

            TempData["MensagemWhatsapp"] = Uri.EscapeDataString(mensagemWhatsappCasamento);

            return View();
        }


    }
}
