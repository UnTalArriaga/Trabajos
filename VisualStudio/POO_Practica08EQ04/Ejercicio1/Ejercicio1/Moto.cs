using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisBibliotecas;
namespace Ejercicio1
{
    class Moto : Vehiculo
    {
        public override string Encender()
        {
            return "Encendiendo Motocicleta";
        }
        public override string Apagar()
        {
            return "Apagando Motocicleta";
        }
        public override string SubirPasajeros()
        {
            return "Subiendo pasajeros a la moto";
        }
    }
}
