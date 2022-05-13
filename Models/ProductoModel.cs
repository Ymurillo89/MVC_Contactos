using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Contactos.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public int Codigo { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public string? Detalle { get; set; }
        public string? Foto { get; set; }
        public int NumStock { get; set; }

        
    }
}
