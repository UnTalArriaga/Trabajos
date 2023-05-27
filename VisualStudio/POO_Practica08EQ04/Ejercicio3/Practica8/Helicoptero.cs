using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica8
{
    class Helicoptero : Moviles_Aereos
    {
        public string Numerohelices { get; set; }

        public string NumeroHelices()
        {
            return "El helicoptero tiene 6 helices";
        }

        public override string EncenderVehiculo() { return "Encendiendo helicoptero"; }
        public override string ApagarVehiculoenVuelo() { return "Apagando helicoptero en vuelo"; }
        public override string SubirPasajeros() { return "Favor de abordar el helicoptero, partiremos en un momento"; }
        public override string Aterrizar() { return "Hemos llegado al destino, en un momento comenzaremos el aterrizaje del helicoptero"; }
    }
}

