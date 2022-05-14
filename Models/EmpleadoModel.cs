﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Contactos.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int? NumDocumento { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
