using Agendamento_de_Eventos.Service;
using Agendamento_de_Eventos.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace Agendamento_de_Eventos.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IagendamentoService _agendaService;

        public AgendamentoController (IagendamentoService iagendamentoService)
        {
            _agendaService = iagendamentoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvento (AgendamentoViewModel agendamento)
        {

            if (!ModelState.IsValid)
            {
                TempData["ErroDataModel"] = "Erro ao agendar o evento. Tente Novamente!";
                return View("Index", agendamento);
            }

            var agenda =  await _agendaService.CriarAgendamento(agendamento);

            if (!agenda.Resultado)
            {
                TempData["dataReservada"] = agenda.MensagemErro;
                return View("Index", agendamento);
            }

            TempData["MensagemURL"] = agenda.MensagemWhatsapp;
            TempData["SucecessAgendamento"] = "Agendamento enviado com Sucesso!!";
            return View("SucessoAgenda");

        }
    }
}
