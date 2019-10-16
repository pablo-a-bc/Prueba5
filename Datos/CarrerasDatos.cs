using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CarrerasDatos
    {
        AcademicosEntities academicosEntities = new AcademicosEntities();
        public void Crear(Carrera carrera)
        {

            academicosEntities.Carrera.Add(carrera);
            academicosEntities.SaveChanges();

        }

        public Entidades.ECarrera BuscarCod(string cod)

        {
            AcademicosEntities academicosEntities = new AcademicosEntities();
            var busqueda = academicosEntities.Carrera.FirstOrDefault(u => u.Codigo == cod);
            if (busqueda != null)
            {
                Entidades.ECarrera eCarrera = new Entidades.ECarrera
                {
                    Id = busqueda.Id,
                    Codigo =busqueda.Codigo,
                    carrera=busqueda.NombreCarrera,
                    Areadenegocio=busqueda.AreaDeNegocio,
                   



                };

                return eCarrera;
            }
            else
            {
                return null;
            }
        }

        public Entidades.ECarrera BuscarId(int Id)

        {
            AcademicosEntities academicosEntities = new AcademicosEntities();
            var busqueda = academicosEntities.Carrera.FirstOrDefault(u => u.Id == Id);
            if (busqueda != null)
            {
                Entidades.ECarrera eCarrera = new Entidades.ECarrera
                {
                    Id = busqueda.Id,
                    Codigo = busqueda.Codigo,
                    carrera = busqueda.NombreCarrera,
                    Areadenegocio = busqueda.AreaDeNegocio,
                    Estado= busqueda.Estado,


                };

                return eCarrera;
            }
            else
            {

                return null;
            }
        }

        public Entidades.ECarrera Actualizar(Entidades.ECarrera eCarrera)

        {
            AcademicosEntities academicosEntities = new AcademicosEntities();
            var carrera = academicosEntities.Carrera.First(u => u.Id == eCarrera.Id);
            if (carrera != null)
            {
                carrera.Codigo = eCarrera.Codigo;
                carrera.NombreCarrera = eCarrera.carrera;
                carrera.AreaDeNegocio = eCarrera.Areadenegocio;
                carrera.Estado = eCarrera.Estado;
                 
                academicosEntities.SaveChanges();

            }

            else
            {

                return null;
            }

            return BuscarCod(eCarrera.Codigo);
        }
        public void Eliminar(int id)

        {
            AcademicosEntities db = new AcademicosEntities();
            var carrera = db.Carrera.First(u => u.Id == id);

            if (carrera != null)
            {
                db.Carrera.Remove(carrera);
                db.SaveChanges();
            }

        }

        public List<Entidades.ECarrera> ObtenerTodos()
        {
            AcademicosEntities db = new AcademicosEntities();
            List<Entidades.ECarrera> lista = new List<Entidades.ECarrera>();
            var todo = (from us in db.Carrera
                        select us).ToList();
            foreach (var u in db.Carrera.ToList())
            {
                lista.Add(new Entidades.ECarrera
                {
                    Id = u.Id,
                    Codigo = u.Codigo,
                    carrera = u.NombreCarrera,
                    Areadenegocio = u.AreaDeNegocio,
                    Estado= u.Estado,
                   
                    
                });
            }
            return lista;
        }
    }
}
