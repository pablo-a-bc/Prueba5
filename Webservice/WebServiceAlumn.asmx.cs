using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Webservice
{
    /// <summary>
    /// Descripción breve de WebServiceAlumn
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceAlumn : System.Web.Services.WebService
    {
        Datos.AlumnoDatos alumnoDatos = new Datos.AlumnoDatos();
        [WebMethod]
        //Crear alumno
        public void Crear(EAlumno eAlumno)
        {
            //if (!string.IsNullOrEmpty(eAlumno.Rut) && !string.IsNullOrEmpty(eAlumno.Nombre) && !string.IsNullOrEmpty(eAlumno.Apellidos) && (eAlumno.Edad > 15 && eAlumno.Edad < 110) && (eAlumno.Sexo > 0 && eAlumno.Sexo <= 2))

            
                Datos.Alumno alumnoDB = new Datos.Alumno();
                alumnoDB.Id = eAlumno.Id;
                alumnoDB.RUT = eAlumno.Rut;
                alumnoDB.Nombre = eAlumno.Nombre;
                alumnoDB.Apellidos = eAlumno.Apellidos;
                alumnoDB.Edad = eAlumno.Edad;
                alumnoDB.Sexo = eAlumno.Sexo;
                
                alumnoDatos.Crear(alumnoDB);

           
            
          


        }

        [WebMethod]
        //buscar
        public EAlumno BuscarRut(String rut)

        {

            Datos.AlumnoDatos alumnoDatos = new Datos.AlumnoDatos();
            return alumnoDatos.BuscarRut(rut);

        }

        [WebMethod]
        //buscarId
        public EAlumno BuscarId(int Id)

        {
            Datos.AlumnoDatos alumnoDatos = new Datos.AlumnoDatos();
            return alumnoDatos.BuscarId(Id);

        }

        [WebMethod]
        //Actualizar
        public bool Actualizar(EAlumno eAlumno)
        {

            if (!string.IsNullOrEmpty(eAlumno.Rut)
                && !string.IsNullOrEmpty(eAlumno.Nombre)
                && !string.IsNullOrEmpty(eAlumno.Apellidos)
                && (eAlumno.Edad > 15 && eAlumno.Edad < 110)
                && (eAlumno.Sexo > 0 && eAlumno.Sexo <= 2)
                )
            {
                Datos.AlumnoDatos alumnoDatos = new Datos.AlumnoDatos();
                alumnoDatos.Actualizar(eAlumno);
                return true;


            }

            else
            {

                return false;

            }
        }
        [WebMethod]

        // ELIMINA UN ID DE LA LISTA DE carrera
        public bool Eliminar(int id)
        {

            Datos.AlumnoDatos alumnoDatos = new Datos.AlumnoDatos();// instancio los datos
            var carrera = alumnoDatos.BuscarId(id);// invoco el metodo de datos para buscar
            if (carrera != null)// si es distinto de nulo
            {
                alumnoDatos.Eliminar(id);// le paso el parametro id al metodo de datos para eliminar de la Bd
                return true;
            }
            else
            {
                return false;
            }
        }


        [WebMethod]

        //lista todo
        public List<EAlumno> Mostrar()
        {

            Datos.AlumnoDatos alumnoDatos = new Datos.AlumnoDatos();
            return alumnoDatos.ObtenerTodos();
        }


    }
}

