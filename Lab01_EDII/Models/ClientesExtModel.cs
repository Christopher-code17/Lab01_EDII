using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab01_EDII.Models
{
    public class ClientesExtModel:ClienteModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Propietario { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Marca { get; set; }


    }
}