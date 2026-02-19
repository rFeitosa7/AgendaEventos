using Agendamento_de_Eventos.Data;
using Agendamento_de_Eventos.Models;

namespace Agendamento_de_Eventos.Repositorio
{
    public class RepositorioAgendamento : InterfaceAgendamento
    {
        private readonly BancoContext _Bancocontext;
        public RepositorioAgendamento (BancoContext bancoContext)
        {
            _Bancocontext = bancoContext;
        }


        public AgendamentoModel BuscarId(int Id)
        {
            return _Bancocontext.Agendamento.FirstOrDefault(x => x.Id == Id);
        }

        public List<AgendamentoModel> BuscarAgendas()
        {
            return _Bancocontext.Agendamento.ToList();
        }



        public AgendamentoModel AddBanco(AgendamentoModel Addmodel)
        {
            _Bancocontext.Agendamento.Add(Addmodel);
            _Bancocontext.SaveChanges();

            return (Addmodel);
        }

        public AgendamentoModel Atualizar(AgendamentoModel updateModel)
        {
            AgendamentoModel agendamento = BuscarId(updateModel.Id);

            if (agendamento == null) throw new Exception("Ocorreu um erro ao atualizar Status do Evento.");

            agendamento.Status = updateModel.Status;

            _Bancocontext.SaveChanges();

            return agendamento;

        }
    }
}
