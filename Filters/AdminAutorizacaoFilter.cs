using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Agendamento_de_Eventos.Filters
{
    public class AdminAutorizacaoFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userAdm = context.HttpContext.Session.GetInt32("AdmLogado");

            if (userAdm != 1)
            {
                context.Result = new RedirectToActionResult("PageMensagemRestrita", "Adm", null);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}