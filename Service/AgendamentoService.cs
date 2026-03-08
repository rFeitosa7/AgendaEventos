using Agendamento_de_Eventos.Enums;
using Agendamento_de_Eventos.Helpers;
using Agendamento_de_Eventos.Models;
using Agendamento_de_Eventos.Repositorio;
using Agendamento_de_Eventos.ViewModel;


namespace Agendamento_de_Eventos.Service
{
    public class AgendamentoService : IagendamentoService
    {
        private readonly InterfaceAgendamento _repositorio;

        public AgendamentoService (InterfaceAgendamento repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ResultadoAgendamento> CriarAgendamento(AgendamentoViewModel ViewModel)
        {
            var AgendaCheia = await _repositorio.BuscarAgendaCheia(ViewModel.DataMarcada.Value);

            if (AgendaCheia != null)
            {
               return new ResultadoAgendamento { Resultado = false, MensagemErro = "A data informada já está reservada. Por gentileza escolha outra." };
            }

            var agendamentoModel = new AgendamentoModel
            {
                Nome = ViewModel.Nome,
                DataEvento = (DateTime)ViewModel.DataMarcada,
                Duracao = (DuracaoEvento)ViewModel.DuracaoEvento,
                TipoEvento = (TipoEvento)ViewModel.TipoEvento,
                NumeroCelular = ViewModel.NumeroCelular,
                Localizacao = ViewModel.Localizacao,
                InfoEvento = ViewModel.InfoEvento,
                Horainicio = (TimeSpan)ViewModel.Horainicio,
            };

            await _repositorio.AddBanco(agendamentoModel);

            string PrecoeHora = string.Empty;

            switch (ViewModel.DuracaoEvento)
            {
                case DuracaoEvento.UmaHora:
                    PrecoeHora = "Duração e Valor contratado : 1 Hora - R$ 250,00";
                    break;

                case DuracaoEvento.DuasHora:
                    PrecoeHora = "Duração e Valor contratado : 2 Horas - R$ 400,00";
                    break;

                case DuracaoEvento.TresHora:
                    PrecoeHora = "Duração e Valor contratado : 3 Horas - R$ 600,00";
                    break;

                case DuracaoEvento.QuatroHora:
                    PrecoeHora = "Duração e Valor contratado : 4 Horas - R$ 800,00";
                    break;

                case DuracaoEvento.CasamentoVozeViolao:
                    PrecoeHora = "Valor contratado para Casamento (Voz e Violão) : R$ 500,00";
                    break;

                case DuracaoEvento.CasamentoGrupo:
                    PrecoeHora = "Valor contratado para Casamento (Grupo L'Acordes) : R$ 1.700";
                    break;
            };


            string mensagemWhatsapp = $"Olá, gostaria de confirmar o agendamento.\n\n" +
                $"Nome : {agendamentoModel.Nome}\n" +
                $"Data Evento : {agendamentoModel.DataEvento.ToString("dd/MM/yyyy")}\n" +
                $"{PrecoeHora}\n" +
                $"Horário de inicio do evento : {agendamentoModel.Horainicio}\n" +
                $"Tipo de Evento : {agendamentoModel.TipoEvento}\n" +
                $"Localização : {agendamentoModel.Localizacao}\n" +
                $"Observações {agendamentoModel.InfoEvento}\n\n" +
                $"Chave PIX : 69992955498 - Nubank - Jucimar Moraes Rodrigues Queiroz";

            return new ResultadoAgendamento { Resultado = true, MensagemWhatsapp = Uri.EscapeDataString(mensagemWhatsapp) };
        }
    }
}
