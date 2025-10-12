using ConsultaUsuariosApp.Models;
using ConsultaUsuariosApp.ViewModels;

using System.Linq;
using System.Web.Mvc;

namespace ConsultaUsuariosApp.Controllers
{
    public class AccederController : Controller
    {
        private DBMVCEntities db = new DBMVCEntities();

        // GET: Acceder/Login
        public ActionResult Login()
        {
            // Si ya hay sesión, redirigir a consulta
            if (Session["Usuario"] != null)
            {
                return RedirectToAction("Consulta", "User");
            }

            return View();
        }

        // POST: Acceder/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Buscar usuario en la base de datos
                var usuario = db.USERS
                    .FirstOrDefault(u => u.Usuario == model.Usuario
                                    && u.Password == model.Password
                                    && u.idEstatus == 1); // Solo usuarios activos

                if (usuario != null)
                {
                    // Crear sesión
                    Session["Usuario"] = usuario.Usuario;
                    Session["UsuarioID"] = usuario.ID;
                    Session["UsuarioNombre"] = usuario.Nombre;

                    // Redirigir a la consulta
                    return RedirectToAction("Consulta", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                }
            }

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}