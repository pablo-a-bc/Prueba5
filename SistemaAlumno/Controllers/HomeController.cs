
using SistemaAlumno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAlumno.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home  -> Mostrar solo index de la pagina
        public ActionResult Index()
        {
            return View();
            //return RedirectToAction("Index");
        }


    }

    
}
