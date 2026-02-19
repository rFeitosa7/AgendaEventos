using Agendamento_de_Eventos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Agendamento_de_Eventos.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataEvento { get; set; }
        public DuracaoEvento Duracao { get; set; }
        public TipoEvento TipoEvento { get; set; }
        public string NumeroCelular { get; set; }
        public string Localizacao {  get; set; }
        public string? InfoEvento {  get; set; }
        public StatusEvento Status { get; set; }
        public TimeSpan Horainicio { get; set; }
    }
}