using Crud1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud1.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(PersonaModel personaModel)
		{
			if (ModelState.IsValid)
			{
				personaModel.GuardarPersona();
				return RedirectToAction("MostrarPersonas");
			}
			else
			{
				return View(personaModel);
			}
		}
		
		public ActionResult ModificarPersona(int id)
		{
			PersonaModel permodel = new PersonaModel();
			permodel = permodel.Consultar(id);
			return View();
		}

		public ActionResult BorrarPersona(int id)
		{
			ViewBag.iduper = id;
			return View();
		}

		[HttpPost]
		public ActionResult ConfirmandoBorrar(int id)
		{
			PersonaModel per = new PersonaModel();
			per.EliminarPersona(id);
			return RedirectToAction("MostrarPersonas");
		}

		[HttpGet]
		public ActionResult MostrarPersonas()
		{
			PersonaModel per = new PersonaModel();
			per.lista = per.ObtenerPersonas();
			return View(per);
		}

		public ActionResult GuardarCambios(PersonaModel per)
		{
			per.Actualizar();
			return RedirectToAction("MostrarPersonas");
		}
	}
}