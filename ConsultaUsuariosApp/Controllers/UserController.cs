using ConsultaUsuariosApp.Filters;
using ConsultaUsuariosApp.Models;
using ConsultaUsuariosApp.ViewModels;

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ConsultaUsuariosApp.Controllers
{
    [VerificaSession]
    public class UserController : Controller
    {
        private DBMVCEntities db = new DBMVCEntities();

        // GET: User/Consulta
        public ActionResult Consulta()
        {
            var usuarios = db.USERS
                .Include(u => u.mSTATU)
                .Where(u => u.idEstatus != 3)
                .Select(u => new QueryViewModel
                {
                    ID = u.ID,
                    Nombre = u.Nombre,
                    Usuario = u.Usuario,
                    Email = u.Email,
                    Edad = u.Edad,
                    Status = u.mSTATU.Status,
                    idEstatus = u.idEstatus
                })
                .ToList();

            return View(usuarios);
        }


        public ActionResult Nuevo()
        {
            ViewBag.Estados = new SelectList(db.mSTATUS.ToList(), "idStatus", "Status");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existeUsuario = db.USERS.Any(u => u.Usuario == model.Usuario);
                if (existeUsuario)
                {
                    ModelState.AddModelError("Usuario", "El usuario ya existe");
                    ViewBag.Estados = new SelectList(db.mSTATUS.ToList(), "idStatus", "Status", model.idEstatus);
                    return View(model);
                }

                var nuevoUsuario = new USER
                {
                    Nombre = model.Nombre,
                    Usuario = model.Usuario,
                    Password = model.Password,
                    Email = model.Email,
                    Edad = model.Edad,
                    idEstatus = model.idEstatus
                };

                db.USERS.Add(nuevoUsuario);
                db.SaveChanges();

                TempData["Mensaje"] = "Usuario creado exitosamente";
                return RedirectToAction("Consulta");
            }

            ViewBag.Estados = new SelectList(db.mSTATUS.ToList(), "idStatus", "Status", model.idEstatus);
            return View(model);
        }

        // GET: User/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Consulta");
            }

            var usuario = db.USERS.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            var model = new EditUserViewModel
            {
                ID = usuario.ID,
                Nombre = usuario.Nombre,
                Usuario = usuario.Usuario,
                Email = usuario.Email,
                Edad = usuario.Edad ?? 0,
                idEstatus = usuario.idEstatus ?? 1
            };

            ViewBag.Estados = new SelectList(db.mSTATUS.ToList(), "idStatus", "Status", model.idEstatus);
            return View(model);
        }

        // POST: User/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.USERS.Find(model.ID);
                if (usuario == null)
                {
                    return HttpNotFound();
                }

                var existeUsuario = db.USERS.Any(u => u.Usuario == model.Usuario && u.ID != model.ID);
                if (existeUsuario)
                {
                    ModelState.AddModelError("Usuario", "El usuario ya existe");
                    ViewBag.Estados = new SelectList(db.mSTATUS.ToList(), "idStatus", "Status", model.idEstatus);
                    return View(model);
                }

                usuario.Nombre = model.Nombre;
                usuario.Usuario = model.Usuario;
                usuario.Email = model.Email;
                usuario.Edad = model.Edad;
                usuario.idEstatus = model.idEstatus;

                if (!string.IsNullOrEmpty(model.Password))
                {
                    usuario.Password = model.Password;
                }

                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Mensaje"] = "Usuario actualizado exitosamente";
                return RedirectToAction("Consulta");
            }

            ViewBag.Estados = new SelectList(db.mSTATUS.ToList(), "idStatus", "Status", model.idEstatus);
            return View(model);
        }

        // GET: User/Borrar/5
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Consulta");
            }

            var usuario = db.USERS.Include(u => u.mSTATU).FirstOrDefault(u => u.ID == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            var model = new DeleteUserViewModel
            {
                ID = usuario.ID,
                Nombre = usuario.Nombre,
                Usuario = usuario.Usuario,
                Email = usuario.Email,
                Edad = usuario.Edad,
                Status = usuario.mSTATU?.Status
            };

            return View(model);
        }

        // POST: User/Borrar/5
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarConfirmado(int id)
        {
            var usuario = db.USERS.Find(id);
            if (usuario != null)
            {
                usuario.idEstatus = 3;
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Mensaje"] = "Usuario eliminado exitosamente";
            }

            return RedirectToAction("Consulta");
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