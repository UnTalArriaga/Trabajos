using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo2
{
    class herbivoro : Animal
    {
        string tipoDientes = "planos";
        public herbivoro()
        {

        }

        override public void Dormir()
        {
            Console.WriteLine(nombre + " está durmiendo en su islita :)");
        }
    }
}
