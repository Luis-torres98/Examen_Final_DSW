using ServiciosWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ServiciosWeb.WebApi.Controllers
{


    public class ClienteController : ApiController
    {
        Negocios2021Entities db = new Negocios2021Entities();

        [HttpGet]
        public IEnumerable<cliente> Get()
        {
            var listado = db.cliente.ToList();
            return listado;
        }

        [HttpGet]
        public cliente Get(int id)
        {
            var cliente = db.cliente.FirstOrDefault(x => x.IdTrabajador == id);
            return cliente;
        }

        [HttpPost]
        public bool Post(cliente cliente)
        {
            db.cliente.Add(cliente);
            return db.SaveChanges() > 0;
        }
        [HttpPut]
        public bool Put(cliente cliente)
        {
            var clienteActualizar = db.cliente.FirstOrDefault(x => x.IdTrabajador == cliente.IdTrabajador);
            clienteActualizar.Nombres = cliente.Nombres;
            clienteActualizar.Apellidos = cliente.Apellidos;
            clienteActualizar.Edad = cliente.Edad;
            clienteActualizar.Direccion = cliente.Direccion;
            clienteActualizar.FechaNac = cliente.FechaNac;

            return db.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var clienteEliminar = db.cliente.FirstOrDefault(x => x.IdTrabajador == id);
            db.cliente.Remove(clienteEliminar);
            return db.SaveChanges() > 0;
        }

        
    }
}
