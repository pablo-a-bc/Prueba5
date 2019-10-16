
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AdmAlumno
    {

        ServiceReferenceA.WebServiceAlumnSoapClient webAlumno = new ServiceReferenceA.WebServiceAlumnSoapClient();
        public void Crear(EAlumno eAlumno)
        {
            if (!string.IsNullOrEmpty(eAlumno.Rut) && !string.IsNullOrEmpty(eAlumno.Nombre) && !string.IsNullOrEmpty(eAlumno.Apellidos) && (eAlumno.Edad > 15 && eAlumno.Edad < 110) && (eAlumno.Sexo > 0 && eAlumno.Sexo <= 2))

            {
                ServiceReferenceA.EAlumno alumno = webAlumno.BuscarRut(eAlumno.Rut);
                if (alumno == null)
                {

                ServiceReferenceA.EAlumno alumnoW = new ServiceReferenceA.EAlumno();

                
                alumnoW.Id = eAlumno.Id;
                alumnoW.Rut = eAlumno.Rut;
                alumnoW.Nombre = eAlumno.Nombre;
                alumnoW.Apellidos = eAlumno.Apellidos;
                alumnoW.Edad = eAlumno.Edad;
                alumnoW.Sexo = eAlumno.Sexo;
                webAlumno.Crear(alumnoW);
                }

            }

          

            }
        // buscar
        public EAlumno BuscarRut(String rut)

        {
           ServiceReferenceA.EAlumno alumnoW = new ServiceReferenceA.EAlumno();

            

            ServiceReferenceA.EAlumno alumno = webAlumno.BuscarRut(rut);
            if (alumno != null)
            {
                EAlumno eAlumno = new EAlumno
                {
                    Id = alumno.Id,
                    Rut = alumno.Rut,
                    Nombre = alumno.Nombre,
                    Apellidos = alumno.Apellidos,
                    Edad = alumno.Edad,
                    Sexo = alumno.Sexo,

                };
                return eAlumno;
            }
            else
            { 
                return null ;
            }

        }

         public EAlumno BuscarId(int Id)

        {
            ServiceReferenceA.EAlumno alumno = webAlumno.BuscarId(Id);
            EAlumno eAlumno = new EAlumno
            {
                Id = alumno.Id,
                Rut = alumno.Rut,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                Edad = alumno.Edad,
                Sexo = alumno.Sexo,
            };

            return eAlumno;

        }


       public bool Actualizar(EAlumno eAlumno)
        {

            if (!string.IsNullOrEmpty(eAlumno.Rut)
                && !string.IsNullOrEmpty(eAlumno.Nombre)
                && !string.IsNullOrEmpty(eAlumno.Apellidos)
                && (eAlumno.Edad > 15 && eAlumno.Edad < 110)
                && (eAlumno.Sexo > 0 && eAlumno.Sexo <= 2)
                )
            {

                ServiceReferenceA.EAlumno alumnoW = new ServiceReferenceA.EAlumno();
                alumnoW.Id = eAlumno.Id;
                alumnoW.Rut = eAlumno.Rut;
                alumnoW.Nombre = eAlumno.Nombre;
                alumnoW.Apellidos = eAlumno.Apellidos;
                alumnoW.Edad = eAlumno.Edad;
                alumnoW.Sexo = eAlumno.Sexo;

                webAlumno.Actualizar(alumnoW);
           
                return true;


            }

            else
            {

                return false;

            }
        }

        //ELIMINA UN ID DE LA LISTA DE carrera
        public bool Eliminar(int id)
        {

           // instancio los datos
            var carrera = webAlumno.BuscarId(id);// invoco el metodo de datos para buscar
            if (carrera != null)// si es distinto de nulo
            {
                webAlumno.Eliminar(id);// le paso el parametro id al metodo de datos para eliminar de la Bd
                return true;
            }
            else
            {
                return false;
            }
        }


        //listar todos los elementos desde WEBSERVICE
        public List<EAlumno> Mostrar()
        {
            ServiceReferenceA.EAlumno[] list = webAlumno.Mostrar();
            List<EAlumno> alumnos = new List<EAlumno>();

            foreach (var datos in list)
            {
                EAlumno alumnoentidad = new EAlumno();
                alumnoentidad.Id = datos.Id;
                alumnoentidad.Rut = datos.Rut;
                alumnoentidad.Nombre = datos.Nombre;
                alumnoentidad.Apellidos = datos.Apellidos;
                alumnoentidad.Edad = datos.Edad;
                alumnoentidad.Sexo = datos.Sexo;
                alumnos.Add(alumnoentidad);
            }
         
            return alumnos;
         }


        
    }
}
