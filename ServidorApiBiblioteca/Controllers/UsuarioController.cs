using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BaseServicios;
using Microsoft.Practices.Unity;
using ServidorApiBiblioteca.Models;

namespace ServidorApiBiblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [Dependency]
        public IServiciosRest<Usuario> Servicio { get; set; }

        public ActionResult Index()
        {
            var data = Servicio.Get();
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public async Task<ActionResult> Alta(Usuario model)
        {
            var data = await Servicio.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Actualizar(int id)
        {
            var data = Servicio.Get(id);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Actualizar(Usuario model)
        {
            await Servicio.Update(model);

            return RedirectToAction("Index");
        }


        public ActionResult Borrar(int id)
        {
            var data = Servicio.Get(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Borrar(Usuario model)
        {
            Servicio.Delete(model.cod_usuario);
            return RedirectToAction("Index");
        }
    }
}