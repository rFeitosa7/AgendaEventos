using Agendamento_de_Eventos.Models;

namespace Agendamento_de_Eventos.Repositorio
{
    public interface InterfaceAgendamento
    {
        Task<AgendamentoModel> AddBanco(AgendamentoModel Addmodel);

        Task<List<AgendamentoModel>> BuscarAgendas();

        Task<AgendamentoModel> BuscarId(int Id);

        Task<AgendamentoModel> Atualizar(AgendamentoModel updateModel);

        Task<AgendamentoModel> BuscarAgendaCheia(DateTime dataCheia);
    }
}