using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica8
{
    class Avion : Moviles_Aereos
    {
        public string Numeroturbinas { get; set; }

        public virtual string NumeroTurbinas() {return "El avión tiene 5 turbinas";}

        public override string tipoCombustible() { return "El tipo de combustible del avión es: Mezcla queroseno-gasolina"; }
        public override string Modelo() { return "El modelo del avión es: McDonnell Dougla"; }
        public override string Pasajeros() { return "La cantidad de pasajeros en el avión es de 29"; }
        public override string EncenderVehiculo() { return "Encendiendo Avión"; }
        public override string ApagarVehiculoenVuelo() { return "Apagando avión en vuelo"; }
        public override string SubirPasajeros() { return "Favor de abordar el avión, partiremos en un momento"; }
        public override string Aterrizar() { return "Hemos llegado al destino, en un momento comenzaremos el aterrizaje del avión"; }
    }
}
