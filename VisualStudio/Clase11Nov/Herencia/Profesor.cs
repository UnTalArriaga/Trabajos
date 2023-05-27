using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Herencia
{
    class Profesor : Persona
    {
        double sueldo;
        public Profesor()
        {

        }
        public void SetSueldo(double ingreso)
        {
            sueldo = ingreso;
        }

        public double GetSueldo()
        {
            return sueldo;
        }

        public string Ensenar()
        {
            return "\nDando clase de POO...";
        }
    }
}
