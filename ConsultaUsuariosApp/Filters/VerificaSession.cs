using System.Web.Mvc;

namespace ConsultaUsuariosApp.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;

            // Verificar si existe la sesión del usuario
            if (session["Usuario"] == null)
            {
                // Si no hay sesión, redirigir al login
                filterContext.Result = new RedirectResult("~/Acceder/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}