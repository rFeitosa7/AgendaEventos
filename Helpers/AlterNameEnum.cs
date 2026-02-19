using Agendamento_de_Eventos.Enums;

namespace Agendamento_de_Eventos.Helpers
{
    public class AlterNameEnum
    {
        public static readonly Dictionary<DuracaoEvento, string> AlterNameDuracao = new()
        {
            {DuracaoEvento.UmaHora, "1 Hora"},
            {DuracaoEvento.DuasHora, "2 Horas"},
            {DuracaoEvento.TresHora, "3 Horas"},
            {DuracaoEvento.QuatroHora, "4 Horas"}
        };
        public static readonly Dictionary<TipoEvento, string> AlterNameTipoEvento = new()
        {
            {TipoEvento.Aniversario, "Aniversário"},
            {TipoEvento.Casamento, "Casamento"},
            {TipoEvento.EventoSocial, "Evento Social"},
            {TipoEvento.EventoCorporativo, "Evento Corporativo"},
            {TipoEvento.EventoReligioso, "Evento Religioso"},
            {TipoEvento.JantarRecepcao, "Jantar e Recepção"},
            {TipoEvento.ApresentacaoCultural, "Apresentação Cultural"},
            {TipoEvento.ApresentacaoInstitucional, "Apresentação Institucional"},
            {TipoEvento.Outro, "Outro tipo de evento"}
        };
    };
}
