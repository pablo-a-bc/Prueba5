using SistemaAlumno.Models;
using Entidades;
using Negocio;
using System;
using System.Web.Mvc;

namespace SistemaAlumno.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Alumno/Create
        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
           

            if (ModelState.IsValid)
            {
                AdmAlumno admAlumno = new AdmAlumno();
                Entidades.EAlumno alm = admAlumno.BuscarRut(alumno.Rut);
                if (alm == null)
                { 
                
                EAlumno eAlumno = new EAlumno
                {
                    Rut = alumno.Rut,
                    Nombre = alumno.Nombre,
                    Apellidos = alumno.Apellidos,
                    Edad = alumno.Edad,
                    Sexo = alumno.Sexo
                };

               
                // if (admAlumno.Crear(eAlumno))

                
             
                admAlumno.Crear(eAlumno);
                //{
                return View("Guardado");

                    //}
                }

                else
                {
                    return View("NoEncontrado");
                }
            }

            return View();
        }

        //// GET: Alumno/Edit/5
        public ActionResult Edit(int id)

        {
            AdmAlumno admAlumno = new AdmAlumno();
            EAlumno alumno = admAlumno.BuscarId(id);

            if (alumno != null)
            {
                return View(alumno);
            }

            else

            {
                return View("Excepcion");

            }
        }

        // POST: Alumno/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidades.EAlumno eAlumno)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    AdmAlumno admAlumno = new AdmAlumno();
                    bool esAct = admAlumno.Actualizar(eAlumno);
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

        //    // GET: Alumno/Delete/5
        public ActionResult Delete(int id)
        {
            AdmAlumno admAlumno = new AdmAlumno();
            EAlumno alumno = admAlumno.BuscarId(id);
            if (alumno != null)
            {
                return View(alumno);
            }
            else

            {
                return View("Excepcion");

            }
        }

        //    // POST: Alumno/Delete/5
    [HttpPost]
        public ActionResult Delete(int id, Entidades.EAlumno eAlumno)
        {
            try
            {
                // TODO: Add delete logic here
                AdmAlumno admAlumno = new AdmAlumno();
                admAlumno.BuscarId(id);

                bool borrar = admAlumno.Eliminar(id);
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

        // buscador

        public ActionResult Buscar()
    {
         return View(new Entidades.EAlumno());
       // return View();
    }

        [HttpPost]
        public ActionResult Buscar(Entidades.EAlumno eAlumno)
        {

            AdmAlumno admAlumno = new AdmAlumno();
            Entidades.EAlumno alumno = admAlumno.BuscarRut(eAlumno.Rut);
            if (alumno != null)
            {
                return View("Encontrado", alumno);
            }

            else
            {

                return View("Nofound");
            }

        }

        public ActionResult Todo()
        {
            AdmAlumno adm = new AdmAlumno();
            return View(adm.Mostrar());

        }
    }
}

