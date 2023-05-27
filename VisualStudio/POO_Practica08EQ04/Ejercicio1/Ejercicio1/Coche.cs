using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisBibliotecas;
namespace Ejercicio1
{
    class Coche : Vehiculo
    {
        public override string Encender()
        {
            return "Encendiendo Coche";
        }
        public override string Apagar()
        {
            return "Apagando Coche";
        }
        public override string SubirPasajeros()
        {
            return "Subiendo pasajeros al coche";
        }
    }
}
