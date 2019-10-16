using Entidades;
using Negocio;
using SistemaAlumno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAlumno.Controllers
{
    public class CarrerasController : Controller
    {
        // GET: Carreras
        public ActionResult Index()
        {
            return View();
        }

        // GET: Carreras/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Carreras/Create
        [HttpPost]
        public ActionResult Create(Carreras carreras)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ECarrera eCarrera = new ECarrera
                    {
                        Codigo = carreras.Codigo,
                        carrera = carreras.carrera,
                        Areadenegocio = carreras.Areadenegocio,
                        Estado = carreras.Estado

                    };

                    AdmCarrera admCarrera = new AdmCarrera();
                    admCarrera.Crear(eCarrera);
                    
                        return View("Guardado");
                   
                }
                else
                {
                    ViewBag.Mensaje = "Carrera no ingresada (vea advertencias)";
                }
              
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        //// GET: Carreras/Edit/5
        public ActionResult Edit(int id)
        {
            AdmCarrera admCarrera = new AdmCarrera();
        ECarrera eCarrera = admCarrera.BuscarId(id);

            if (eCarrera != null)
            {
                return View(eCarrera);
    }

            else

            {
                return View("Excepcion");

}
        }

        //// POST: Carreras/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidades.ECarrera eCarrera)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    AdmCarrera admCarrera = new AdmCarrera();
                    bool esAct = admCarrera.Actualizar(eCarrera);
                    if (esAct)
                    {
                        return View("Actualizado");

                    }
                }
                else
                {


                    ViewBag.Mensaje = "Alumno no editado (vea advertencias)";
                }
                return View();

            }
            catch
            {
                return View("Excepcion");
            }
        }

        //// GET: Carreras/Delete/5
        public ActionResult Delete(int id)
        {
            AdmCarrera admCarrera = new AdmCarrera();
            ECarrera carrera = admCarrera.BuscarId(id);
           if (carrera != null)
           {
               return View(carrera);
            }
           else

           {
               return View("Excepcion");

           }
        }

        //// POST: Carreras/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Entidades.ECarrera eCarrera)
        {
            try
           {
               // TODO: Add delete logic here
               AdmCarrera admCarrera = new AdmCarrera();
               admCarrera.BuscarId(id);

               bool borrar = admCarrera.Eliminar(id);
               if (borrar)
               {
                   return View("Borrado");
               }
               else
               {
                   return View("Excepcion");
               }
           }
           catch
            {
                return View("Excepcion");
           }
        }
        public ActionResult Buscar()
    {
        return View(new Entidades.ECarrera());
    }

    [HttpPost]
        public ActionResult Buscar(Entidades.ECarrera eCarrera)
        {

            AdmCarrera admCarrera = new AdmCarrera();
            Entidades.ECarrera carrera = admCarrera.BuscarCod(eCarrera.Codigo);
            if (carrera != null)
            {
                return View("Encontrado", carrera);
            }

            else
            {

                return View("Nofound");
            }


        }

        public ActionResult Todo()
        {
         AdmCarrera adm = new AdmCarrera();
         return View(adm.Mostrar());

        }
    }
}
