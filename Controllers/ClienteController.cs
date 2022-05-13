using Microsoft.AspNetCore.Mvc;
using MVC_Contactos.Data;
using MVC_Contactos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Contactos.Controllers
{
    public class ClienteController : Controller
    {

        ClienteData cliente = new ClienteData();

        public IActionResult MostarClientes()
        {
            var oLista = cliente.Listarclientes();
            //Motrar la lista de clientes
            return View(oLista);
        }

        public IActionResult GuardarClientes()
        {
            //Solo devuelve la vista(después de realizar una posible actualización o guardado de datos)
            return View();
        }

        [HttpPost]
        //Para obtener los datos del formulario y mandarlos
        public IActionResult GuardarClientes(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();

            
            var repuesta = cliente.Guardarcliente(oCliente);
            if (repuesta)
            
                return RedirectToAction("MostarClientes");
            else
            //Recibr objeto y guardarlo en la base de datos
            return View();
        }

        public IActionResult EditarClientes(int IdCliente)
        {
            //Solo devuelve la vista(después de realizar una posible actualización o guardado de datos)
            var oCliente = cliente.Obtenercliente(IdCliente);
            return View(oCliente);
        }

        [HttpPost]
        //Para obtener los datos del formulario y mandarlos
        public IActionResult EditarClientes(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();


            var repuesta = cliente.EditarCliente(oCliente);
            if (repuesta)

                return RedirectToAction("MostarClientes");
            else
                //Recibr objeto y guardarlo en la base de datos
                return View();
        }

        public IActionResult EliminarClientes(int IdCliente)
        {
            //Solo devuelve la vista(después de realizar una posible actualización o guardado de datos)
            var oCliente = cliente.Obtenercliente(IdCliente);
            return View(oCliente);
        }

        [HttpPost]
        //Para obtener los datos del formulario y mandarlos
        public IActionResult EliminarClientes(ClienteModel oCliente)
        {
           var repuesta = cliente.EliminarCliente(oCliente.IdCliente);
            if (repuesta)

                return RedirectToAction("MostarClientes");
            else
                //Recibr objeto y guardarlo en la base de datos
                return View();
        }

    }
}
