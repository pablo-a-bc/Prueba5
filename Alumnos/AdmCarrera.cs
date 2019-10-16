using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class AdmCarrera
    {
        ServiceReferenceC.WebServiceCarreraSoapClient webCarrera = new ServiceReferenceC.WebServiceCarreraSoapClient();

        public void Crear(ECarrera eCarrera)
        {
            if (!string.IsNullOrEmpty(eCarrera.Codigo) &&
                (!string.IsNullOrEmpty(eCarrera.carrera) | eCarrera.Equals("Informática") | eCarrera.Equals("Telecomunicaciones") | eCarrera.Equals("Finanzas"))
                && !string.IsNullOrEmpty(eCarrera.Areadenegocio))
            {
                ServiceReferenceC.ECarrera carerraW = new ServiceReferenceC.ECarrera();
                carerraW.Id = eCarrera.Id;
                carerraW.Codigo = eCarrera.Codigo;
                carerraW.carrera = eCarrera.carrera;
                carerraW.Areadenegocio = eCarrera.Areadenegocio;
                carerraW.Estado = eCarrera.Estado;
                webCarrera.Crear(carerraW);



                
            }


           


        }

        public ECarrera BuscarCod(String cod)

        {

            ServiceReferenceC.ECarrera carerraW = new ServiceReferenceC.ECarrera();
            ServiceReferenceC.ECarrera carrera = webCarrera.BuscarCod(cod);
            if (carrera != null)
            {
                ECarrera eCarrera = new ECarrera
                {
                    Id = carrera.Id,
                    Codigo = carrera.Codigo,
                    carrera = carrera.carrera,
                    Areadenegocio = carrera.Areadenegocio,
                    Estado = carrera.Estado
                

            };
                return eCarrera;
            }
            else
            {
                return null;
            }
           

       }

        public ECarrera BuscarId(int Id)

       {
            ServiceReferenceC.ECarrera carerraW = new ServiceReferenceC.ECarrera();
            ServiceReferenceC.ECarrera carrera = webCarrera.BuscarId(Id);
            if (carrera != null)
            {
                ECarrera eCarrera = new ECarrera
                {
                    Id = carrera.Id,
                    Codigo = carrera.Codigo,
                    carrera = carrera.carrera,
                    Areadenegocio = carrera.Areadenegocio,
                    Estado = carrera.Estado


                };
                return eCarrera;
            }
            else
            {
                return null;
            }

        }

        public bool Actualizar(ECarrera eCarrera)
        {

            if (!string.IsNullOrEmpty(eCarrera.Codigo) &&
                (!string.IsNullOrEmpty(eCarrera.carrera) | eCarrera.Equals("Informática") | eCarrera.Equals("Telecomunicaciones") | eCarrera.Equals("Finanzas"))
                && !string.IsNullOrEmpty(eCarrera.Areadenegocio))
            {


                ServiceReferenceC.ECarrera carerraW = new ServiceReferenceC.ECarrera();
                carerraW.Id = eCarrera.Id;
                carerraW.Codigo = eCarrera.Codigo;
                carerraW.Estado = eCarrera.Estado;
                carerraW.Areadenegocio = eCarrera.Areadenegocio;
                carerraW.carrera = eCarrera.carrera;


                webCarrera.Actualizar(carerraW);

                return true;


            }

            else
            {

                return false;

            }
        }
        public bool Eliminar(int id)
        {

          
           var carrera = webCarrera.BuscarId(id);// invoco el metodo de datos para buscar
           if (carrera != null)// si es distinto de nulo
            {
               webCarrera.Eliminar(id);// le paso el parametro id al metodo de datos para eliminar de la Bd
               return true;
            }
           else
           {
               return false;
            }
        }


        // MOSTRAR TODAD LAS CARRERASS 
        public List<ECarrera> Mostrar()
        {
            ServiceReferenceC.ECarrera [] list = webCarrera.Mostrar();
            List<ECarrera> carrera= new List<ECarrera>();

            foreach (var datos in list)
            {
                ECarrera carreratransformada = new ECarrera();
                carreratransformada.Id = datos.Id;
                carreratransformada.Codigo = datos.Codigo;
                carreratransformada.Estado = datos.Estado;
                carreratransformada.Areadenegocio = datos.Areadenegocio;
                carreratransformada.carrera = datos.carrera;
                carrera.Add(carreratransformada);
            }

            return carrera;

           
       }
    }
}

