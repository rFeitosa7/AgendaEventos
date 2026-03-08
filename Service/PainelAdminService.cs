using Agendamento_de_Eventos.Enums;
using Agendamento_de_Eventos.Helpers;
using Agendamento_de_Eventos.Models;
using Agendamento_de_Eventos.Repositorio;
using Agendamento_de_Eventos.Service.Interface;
using Agendamento_de_Eventos.ViewModel;

namespace Agendamento_de_Eventos.Service
{
    public class PainelAdminService : IPainelAdmin
    {
        private readonly IConfiguration _iconfiguration;
        private readonly InterfaceAgendamento _iagendamento;

        public PainelAdminService (IConfiguration iconfiguration, InterfaceAgendamento interfaceAgendamento)
        {
            _iconfiguration = iconfiguration;
            _iagendamento = interfaceAgendamento;
        }

        public async Task<List<AgendamentoModel>> ListarAgendas()
        {
            return await _iagendamento.BuscarAgendas(); 
        }

        public ResultadoAgendamento LoginPainelAdm(LoginAdmViewModel admViewModel)
        {
            var userConfig = _iconfiguration["LoginAdm:Usuario"];
            var senhaConfig = _iconfiguration["LoginAdm:Senha"];

            if (admViewModel.usuario == userConfig && admViewModel.senha == senhaConfig)
            { 
                return new ResultadoAgendamento { Resultado = true};
            }
            return new ResultadoAgendamento { Resultado = false };
        }

        public async Task<ResultadoAgendamento> AtualizarStatus(int id, StatusEvento statusEvento)
        {
            var agendaBuscada = await _iagendamento.BuscarId(id);

            if (agendaBuscada == null)
            {
                return new ResultadoAgendamento { Resultado = false };
            }

            agendaBuscada.Status = statusEvento;
            await _iagendamento.Atualizar(agendaBuscada);
            return new ResultadoAgendamento { Resultado = true };

        }
    }
}
