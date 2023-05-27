using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica8
{
    class Moviles_Aereos
    {
        public string Tipocombustible { get; set; }
        public string modelo { get; set; }
        public string pasasjeros { get; set; }
        public string encenderVehiculo { get; set; }
        public string apagarVehiculoenvuelo { get; set; }
        public string subirpasasjeros { get; set; }
        public string aterrizar { get; set; }

        public virtual string tipoCombustible ()
        {
            return "Diesel";
        }
        public virtual string Modelo ()
        {
            return "Boeing";
        }
        public virtual string Pasajeros ()
        {
            return "La cantidad de pasajeros abordo del avion son 43.";
        }
        public virtual string EncenderVehiculo()
        {
            return "Encendiendo Vehiculo.";
        }
        public virtual string ApagarVehiculoenVuelo()
        {
            return "Apagando vehiculo en vuelo.";
        }
        public virtual string SubirPasajeros()
        {
            return "Pasajeros, favor de abordar el vehiculo";
        }
        public virtual string Aterrizar()
        {
            return "Hemos llegado al destino, en un momento comenzaremos el aterrizaje";
        }


    }
}
