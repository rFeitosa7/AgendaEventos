using Agendamento_de_Eventos.Data;
using Agendamento_de_Eventos.Enums;
using Agendamento_de_Eventos.Filters;
using Agendamento_de_Eventos.Helpers;
using Agendamento_de_Eventos.Models;
using Agendamento_de_Eventos.Repositorio;
using Agendamento_de_Eventos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Agendamento_de_Eventos.Controllers
{
    public class AdmController : Controller
    {
        private readonly InterfaceAgendamento _interfaceAgendamento;
        private readonly IConfiguration _iconfiguration;

        public AdmController (InterfaceAgendamento interfaceAgendamento, IConfiguration configuration)
        {
            _interfaceAgendamento = interfaceAgendamento;
            _iconfiguration = configuration;
        }


        [ServiceFilter(typeof(AdminAutorizacaoFilter))]
        public IActionResult Index()
        {
            List<AgendamentoModel> agendas = _interfaceAgendamento.BuscarAgendas();

            ViewBag.NewNameDuracao = AlterNameEnum.AlterNameDuracao;
            ViewBag.NewNameTipoEvento = AlterNameEnum.AlterNameTipoEvento;

            return View(agendas);
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
        public IActionResult Login(LoginAdmViewModel loginAdm)
        {
            var userConfig = _iconfiguration["LoginAdm:Usuario"];
            var senhaConfig = _iconfiguration["LoginAdm:Senha"];

            if (!ModelState.IsValid)
            {
                TempData["ErrorLoginAdm"] = "Campo usuário e/ou senha não preenchidos. Por favor, preencha os campos.";
                return View("Login", loginAdm);
            }

            if (loginAdm.usuario == userConfig && loginAdm.senha == senhaConfig)
            {
                HttpContext.Session.SetInt32("AdmLogado", 1);
                return RedirectToAction("Index");
            }
            return RedirectToAction("PageMensagemRestrita");
        }

        [HttpPost]
        public IActionResult AtualizarStatus(int id, StatusEvento statusEvento)
        {
            AgendamentoModel agendamento = _interfaceAgendamento.BuscarId(id);

            if (agendamento == null)
            {
                TempData["AgendaNull"] = "Agendamento não Encontrado!";
                return RedirectToAction("Index");
            }

            agendamento.Status = statusEvento;
            _interfaceAgendamento.Atualizar(agendamento);

            TempData["SucessAgendaStatus"] = "Status do evento alterado com sucesso!!";
            return RedirectToAction("Index");
        }
    }
}
