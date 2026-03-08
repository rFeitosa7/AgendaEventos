using Agendamento_de_Eventos.Helpers;
using Agendamento_de_Eventos.ViewModel;

namespace Agendamento_de_Eventos.Service
{
    public interface IagendamentoService
    {
        Task <ResultadoAgendamento> CriarAgendamento(AgendamentoViewModel ViewModel);
    }
}
