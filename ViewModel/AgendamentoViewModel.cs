using Agendamento_de_Eventos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Agendamento_de_Eventos.ViewModel
{
    public class AgendamentoViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime? DataMarcada { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [EnumDataType(typeof(DuracaoEvento), ErrorMessage = "Opção Inválida! Escolha Novamente.")]
        public DuracaoEvento? DuracaoEvento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [EnumDataType(typeof(TipoEvento), ErrorMessage = "Opção Inválida! Escolha Novamente.")]
        public TipoEvento? TipoEvento  { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string NumeroCelular { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Localizacao { get; set; }

        public string? InfoEvento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public TimeSpan? Horainicio { get; set; }
    }
}
