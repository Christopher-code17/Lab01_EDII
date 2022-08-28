using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Lab01_EDII.Models.Datos;

namespace Lab01_EDII.Models
{
    public class Clientes
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string NumSerie { get; set; }

    }
}
