using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServicesApiRest.Models;

namespace WebServicesApiRest.Controllers
{
    public class DatosController : ApiController
    {
        DatabaseRegistrosEntities conn = new DatabaseRegistrosEntities();

        [HttpGet]
        public List<DatosEntities> listaDatos ()
        {
            List<DatosEntities> datos = new List<DatosEntities>();
            var datosBD = conn.DatosRegistro.ToList();
            foreach (var item in datosBD)
            {
                datos.Add(new DatosEntities
                {
                    
                    Compania = item.Compania,
                    Contacto = item.Contacto,
                    Correo = item.Correo,
                    Telefono = item.Telefono
                    
                });
            }
            return datos;
            
        }
        [HttpPost]
        public bool datos(DatosEntities newDato)
        {
            bool response = false;
            try
            {
                DatosRegistro addDatos = (new DatosRegistro { Compania = newDato.Compania,
                    Contacto = newDato.Contacto,
                    Correo = newDato.Correo,
                    Telefono = newDato.Telefono
                });

                conn.DatosRegistro.Add(addDatos);
                conn.SaveChanges();
                response = true;

            }
            catch (Exception )
            {
                throw;
            }
            return response;
        }


    }
}
