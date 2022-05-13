using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para especificar los datos necesarios.
using System.ComponentModel.DataAnnotations;

namespace MVC_Contactos.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public int NumDocumento { get; set; }

        [Required]
        public string? Direccion { get; set; }
        
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
