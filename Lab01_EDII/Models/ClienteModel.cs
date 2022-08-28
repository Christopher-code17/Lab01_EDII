using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Lab01_EDII.Models.Datos;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Lab01_EDII.Models
{
    public class ClienteModel:IComparable<ClienteModel>
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string NumSerie { get; set; }

        public int CompareTo(VehiculoModel otro)
        {
            if (otro == null)
            {
                return 0;
            }
            else
            {
                return this.NumSerie.CompareTo(otro.NumSerie);
            }
        }
        //Revisar la linea 24
        public static List<VehiculoExtModel> Filter(string name)
        {
            return Singleton.Instance.miArbolVehiculos.ObtenerLista().Where(x => x.NumSerie.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}