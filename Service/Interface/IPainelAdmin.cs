using Agendamento_de_Eventos.Enums;
using Agendamento_de_Eventos.Helpers;
using Agendamento_de_Eventos.Models;
using Agendamento_de_Eventos.ViewModel;

namespace Agendamento_de_Eventos.Service.Interface
{
    public interface IPainelAdmin
    {

        Task<List<AgendamentoModel>> ListarAgendas();
        ResultadoAgendamento LoginPainelAdm(LoginAdmViewModel admViewModel);
        Task<ResultadoAgendamento> AtualizarStatus(int id, StatusEvento statusEvento);
    }
}
