using Microsoft.AspNetCore.Mvc;
using MVC_Contactos.Data;
using MVC_Contactos.Models;


namespace MVC_Contactos.Controllers
{
    public class EmpleadoController : Controller
    {

        EmpleadoData empleado = new EmpleadoData();

        public IActionResult MostrarEmpleado()
        {
            var oLista = empleado.ListarEmpleados();
            //Motrar la lista de clientes
            return View(oLista);
        }

        public IActionResult GuardarEmpleado()
        {
            //Solo devuelve la vista(después de realizar una posible actualización o guardado de datos)
            return View();
        }

        [HttpPost]
        //Para obtener los datos del formulario y mandarlos
        public IActionResult GuardarEmpleado(EmpleadoModel oEmpleado)
        {
            if (!ModelState.IsValid)
                return View();


            var repuesta = empleado.GuardarEmpleado(oEmpleado);
            if (repuesta)

                return RedirectToAction("MostrarEmpleado");
            else
                //Recibr objeto y guardarlo en la base de datos
                return View();
        }

        public IActionResult EditarEmpleado(int IdEmpleado)
        {
            //Solo devuelve la vista(después de realizar una posible actualización o guardado de datos)
            var oEmpleado = empleado.ObtenerEmpleado(IdEmpleado);
            return View(oEmpleado);
        }

        [HttpPost]
        //Para obtener los datos del formulario y mandarlos
        public IActionResult EditarEmpleado(EmpleadoModel oEmpleado)
        {
            if (!ModelState.IsValid)
                return View();


            var repuesta = empleado.EditarEmpleado(oEmpleado);
            if (repuesta)

                return RedirectToAction("MostrarEmpleado");
            else
                //Recibr objeto y guardarlo en la base de datos
                return View();
        }

        public IActionResult EliminarEmpleado(int IdEmpleado)
        {
            //Solo devuelve la vista(después de realizar una posible actualización o guardado de datos)
            var oEmpleado = empleado.ObtenerEmpleado(IdEmpleado);
            return View(oEmpleado);
        }

        [HttpPost]
        //Para obtener los datos del formulario y mandarlos
        public IActionResult EliminarEmpleado(EmpleadoModel oEmpleado)
        {
            var repuesta = empleado.EliminarEmpleado(oEmpleado.IdEmpleado);
            if (repuesta)

                return RedirectToAction("MostrarEmpleado");
            else
                //Recibr objeto y guardarlo en la base de datos
                return View();
        }

    }
}