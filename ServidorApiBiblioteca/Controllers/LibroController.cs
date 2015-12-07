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
    public class LibroController : Controller
    {
        [Dependency]
        public IServiciosRest<Libro> Servicio { get; set; }
        // GET: Libro
        public ActionResult Index()
        {
            var data = Servicio.Get();
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new Libro());
        }

        [HttpPost]
        public async Task<ActionResult> Alta(Libro model)
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
        public async Task<ActionResult> Actualizar(Libro model)
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
        public ActionResult Borrar(Libro model)
        {
            Servicio.Delete(model.cod_libro);
            return RedirectToAction("Index");
        }

    }
}