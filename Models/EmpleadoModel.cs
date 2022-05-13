﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Contactos.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public int NumDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
