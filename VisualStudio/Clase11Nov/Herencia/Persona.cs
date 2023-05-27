using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    class Persona
    {
        public string nombre;

        public Persona()
        {

        }

        public void SetNombre(string name)
        {
            nombre = name;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public string Asistir()
        {
            return "\nAsistiendo a Clases... \n";
        }
    }
}
