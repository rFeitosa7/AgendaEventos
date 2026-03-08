using Agendamento_de_Eventos.Enums;
using Agendamento_de_Eventos.Filters;
using Agendamento_de_Eventos.Helpers;
using Agendamento_de_Eventos.Service.Interface;
using Agendamento_de_Eventos.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace Agendamento_de_Eventos.Controllers
{
    public class AdmController : Controller
    {
        private readonly IPainelAdmin _painelAdmin;

        public AdmController (IPainelAdmin painelAdmin)
        {
            _painelAdmin = painelAdmin;
        }


        [ServiceFilter(typeof(AdminAutorizacaoFilter))]
        public async Task<IActionResult> Index()
        {
            var agendasBuscadas = await _painelAdmin.ListarAgendas();

            ViewBag.NewNameDuracao = AlterNameEnum.AlterNameDuracao;
            ViewBag.NewNameTipoEvento = AlterNameEnum.AlterNameTipoEvento;

            return View(agendasBuscadas);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult PageMensagemRestrita()
        {
            return View();
        }


        [HttpPost]
        public  IActionResult Login(LoginAdmViewModel loginAdm)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorLoginAdm"] = "Campo usuário e/ou senha não preenchidos. Por favor, preencha os campos.";
                return View("Login", loginAdm);
            }

            var loginPainelAdm = _painelAdmin.LoginPainelAdm(loginAdm);

            if (!loginPainelAdm.Resultado)
            {
                return RedirectToAction("PageMensagemRestrita");
            }
            HttpContext.Session.SetInt32("AdmLogado", 1);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarStatus(int id, StatusEvento statusEvento)
        {
            var agendaBuscada = await _painelAdmin.AtualizarStatus(id, statusEvento);

            if (!agendaBuscada.Resultado)
            {
                TempData["AgendaNull"] = "Agendamento não Encontrado!";
                return RedirectToAction("Index");
            }
            TempData["SucessAgendaStatus"] = "Status do evento alterado com sucesso!!";
            return RedirectToAction("Index");

        }
    }
}
