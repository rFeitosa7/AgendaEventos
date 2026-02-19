using Agendamento_de_Eventos.Models;
using Agendamento_de_Eventos.ViewModel;

namespace Agendamento_de_Eventos.Repositorio
{
    public interface InterfaceAgendamento
    {
        AgendamentoModel AddBanco(AgendamentoModel Addmodel);

        List<AgendamentoModel> BuscarAgendas();

        AgendamentoModel BuscarId(int Id);

        AgendamentoModel Atualizar(AgendamentoModel updateModel);
    }
}