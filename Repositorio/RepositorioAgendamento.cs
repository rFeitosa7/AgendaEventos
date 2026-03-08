using Agendamento_de_Eventos.Data;
using Agendamento_de_Eventos.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento_de_Eventos.Repositorio
{
    public class RepositorioAgendamento : InterfaceAgendamento
    {
        private readonly BancoContext _Bancocontext;
        public RepositorioAgendamento (BancoContext bancoContext)
        {
            _Bancocontext = bancoContext;
        }


        public async Task<AgendamentoModel>  BuscarId(int Id)
        {
            return await _Bancocontext.Agendamento
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<AgendamentoModel>> BuscarAgendas()
        {
            return await _Bancocontext.Agendamento.ToListAsync();
        }

        public async Task<AgendamentoModel> BuscarAgendaCheia(DateTime dataCheia)
        {
            return await _Bancocontext.Agendamento.
                FirstOrDefaultAsync(x => x.DataEvento.Date == dataCheia.Date);
        }


        public async Task<AgendamentoModel> AddBanco(AgendamentoModel Addmodel)
        {
            await _Bancocontext.Agendamento.AddAsync(Addmodel);
            await _Bancocontext.SaveChangesAsync();

            return (Addmodel);
        }

        public async Task<AgendamentoModel>  Atualizar(AgendamentoModel updateModel)
        {
            AgendamentoModel agendamento = await BuscarId(updateModel.Id);

            if (agendamento == null) throw new Exception("Ocorreu um erro ao atualizar Status do Evento.");

            agendamento.Status = updateModel.Status;

            await _Bancocontext.SaveChangesAsync();

            return agendamento;

        }
    }
}
