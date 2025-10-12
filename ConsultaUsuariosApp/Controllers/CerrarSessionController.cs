using System.Web.Mvc;

namespace ConsultaUsuariosApp.Controllers
{
    public class CerrarSessionController : Controller
    {
        // GET: CerrarSession/Logout
        public ActionResult Logout()
        {
            // Limpiar todas las variables de sesión
            Session.Clear();
            Session.Abandon();

            // Redirigir al login
            return RedirectToAction("Login", "Acceder");
        }
    }
}