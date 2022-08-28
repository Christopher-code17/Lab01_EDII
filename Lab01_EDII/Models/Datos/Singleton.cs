using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab01_EDII.Models;


namespace Lab01_EDII.Models.Datos
{
    public class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }
        public int bandera;
        public List<VehiculoExtModel> Aux = new List<VehiculoExtModel>();
        public Clases.ArbolBinario<VehiculoExtModel> miArbolVehiculos = new Clases.ArbolBinario<VehiculoExtModel>();
        public Clases.Arbol_AVL<VehiculoExtModel> miAVL = new Clases.Arbol_AVL<VehiculoExtModel>();

    }
}