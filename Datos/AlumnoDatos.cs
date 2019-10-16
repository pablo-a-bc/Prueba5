using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AlumnoDatos
    {
        AcademicosEntities academicosEntities = new AcademicosEntities();
        public void Crear(Alumno alumno)
        {
            var rut = alumno.RUT;
            var busqueda = academicosEntities.Alumno.FirstOrDefault(u => u.RUT == rut);
            if (busqueda == null)
            {
            academicosEntities.Alumno.Add(alumno);
            academicosEntities.SaveChanges();
            }
           


        }

        public Entidades.EAlumno BuscarRut(string rut)

        {
            AcademicosEntities academicosEntities = new AcademicosEntities();
            var busqueda = academicosEntities.Alumno.FirstOrDefault(u => u.RUT == rut);
            if (busqueda != null)
            {
                Entidades.EAlumno eAlumno = new Entidades.EAlumno
                {
                    Id = busqueda.Id,
                    Rut = busqueda.RUT,
                    Nombre = busqueda.Nombre,
                    Apellidos = busqueda.Apellidos,
                    Edad = busqueda.Edad,
                    Sexo = busqueda.Sexo,



                };

                return eAlumno;
            }

            else
            {
                return null;
            }
        }


        public Entidades.EAlumno BuscarId(int Id)

        {
            AcademicosEntities academicosEntities = new AcademicosEntities();
            var busqueda = academicosEntities.Alumno.FirstOrDefault(u => u.Id == Id);
            if(busqueda != null)
            { 
            Entidades.EAlumno eAlumno = new Entidades.EAlumno
            {
                Id = busqueda.Id,
                Rut = busqueda.RUT,
                Nombre = busqueda.Nombre,
                Apellidos = busqueda.Apellidos,
                Edad = busqueda.Edad,
                Sexo = busqueda.Sexo,



            };

            return eAlumno;
            }
            else{

                return null;
            }
        }

         public Entidades.EAlumno Actualizar(Entidades.EAlumno eAlumno)

          {
              AcademicosEntities academicosEntities = new AcademicosEntities();
              var alumno = academicosEntities.Alumno.First(u => u.Id == eAlumno.Id);
              if(alumno != null )
              {
                  alumno.RUT = eAlumno.Rut;
                  alumno.Nombre = eAlumno.Nombre;
                  alumno.Apellidos = eAlumno.Apellidos;
                  alumno.Edad = eAlumno.Edad;
                  alumno.Sexo = eAlumno.Sexo;

                  academicosEntities.SaveChanges();

              }

              else
              {

                  return null;
              }

              return BuscarRut(eAlumno.Rut);
          }


        public void Eliminar(int idAlumno)

        {
            AcademicosEntities db = new AcademicosEntities();
            var alumno = db.Alumno.First(u => u.Id == idAlumno);

            if (alumno != null)
            {
                db.Alumno.Remove(alumno);
                db.SaveChanges();
            }

        }

        public List<Entidades.EAlumno> ObtenerTodos()
        {

   

            AcademicosEntities db = new AcademicosEntities();
            List<Entidades.EAlumno> lista = new List<Entidades.EAlumno>();
            var todo = (from us in db.Alumno
                        select us).ToList();
            foreach (var u in db.Alumno.ToList())
            {
                lista.Add(new Entidades.EAlumno
                {
                    Id = u.Id,
                    Rut = u.RUT,
                    Nombre = u.Nombre,
                    Apellidos = u.Apellidos,
                    Edad = u.Edad,
                    Sexo = u.Sexo
                });
            }
            return lista;
        }
    }
}
