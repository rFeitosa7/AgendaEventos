using System.ComponentModel.DataAnnotations;

namespace Agendamento_de_Eventos.ViewModel
{
    public class LoginAdmViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string senha { get; set; }
    }
}
