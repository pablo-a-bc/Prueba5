using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Webservice
{
    /// <summary>
    /// Descripción breve de WebServiceCarrera
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCarrera : System.Web.Services.WebService
    {
        Datos.CarrerasDatos CarrerasDatos = new Datos.CarrerasDatos();
        [WebMethod]
        public void Crear(ECarrera eCarrera)
        {
            if (!string.IsNullOrEmpty(eCarrera.Codigo) &&
                (!string.IsNullOrEmpty(eCarrera.carrera) | eCarrera.Equals("Informática") | eCarrera.Equals("Telecomunicaciones") | eCarrera.Equals("Finanzas"))
                && !string.IsNullOrEmpty(eCarrera.Areadenegocio))
            {

                Datos.Carrera carrerabd = new Datos.Carrera();
                carrerabd.Id = eCarrera.Id;
                carrerabd.Codigo = eCarrera.Codigo;
                carrerabd.NombreCarrera = eCarrera.carrera;
                carrerabd.AreaDeNegocio = eCarrera.Areadenegocio;
                carrerabd.Estado = eCarrera.Estado;

                CarrerasDatos.Crear(carrerabd);


                
            }




        }
        [WebMethod]
        public ECarrera BuscarCod(String cod)

        {

            Datos.CarrerasDatos carrerasDatos = new Datos.CarrerasDatos();
            return carrerasDatos.BuscarCod(cod);

        }
        [WebMethod]
        public ECarrera BuscarId(int Id)

        {
            Datos.CarrerasDatos carreraDatos = new Datos.CarrerasDatos();
            return carreraDatos.BuscarId(Id);

        }
        [WebMethod]
        public bool Actualizar(ECarrera eCarrera)
        {

            if (!string.IsNullOrEmpty(eCarrera.Codigo) &&
                (!string.IsNullOrEmpty(eCarrera.carrera) | eCarrera.Equals("Informática") | eCarrera.Equals("Telecomunicaciones") | eCarrera.Equals("Finanzas"))
                && !string.IsNullOrEmpty(eCarrera.Areadenegocio))
            {
                Datos.CarrerasDatos carrerasDatos = new Datos.CarrerasDatos();
                carrerasDatos.Actualizar(eCarrera);
                return true;


            }

            else
            {

                return false;

            }
        }

        [WebMethod]
        public bool Eliminar(int id)
        {

            Datos.CarrerasDatos carrerasDatos = new Datos.CarrerasDatos();// instancio los datos
            var carrera = carrerasDatos.BuscarId(id);// invoco el metodo de datos para buscar
            if (carrera != null)// si es distinto de nulo
            {
                carrerasDatos.Eliminar(id);// le paso el parametro id al metodo de datos para eliminar de la Bd
                return true;
            }
            else
            {
                return false;
            }
        }


        [WebMethod]
        public List<ECarrera> Mostrar()
        {

            Datos.CarrerasDatos carreraDatos = new Datos.CarrerasDatos();
            return carreraDatos.ObtenerTodos();
        }
    }
}
